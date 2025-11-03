using AutoMapper;
using Vexo.Application.Common;
using Vexo.Application.Common.Errors;
using Vexo.Application.Common.Messages;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.Repositories;
using Vexo.Application.Interfaces.Repositories.Read;
using Vexo.Application.Interfaces.Security;
using Vexo.Application.Interfaces.Services;
using Vexo.Domain.Entities;
using Vexo.Infrastructure.Services.Security;

namespace Vexo.Infrastructure.Services;

public class AuthService(
    IUserService userService,
    IRefreshTokenReadRepository refreshTokenRepository,
    ITokenService tokenService,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IAuthService
{
    public async Task<Result<AuthResponseDto>> SignInAsync(string email, string password)
    {
        var user = await userService.FindByEmailAsync(email);
        if (user is null) return AppError.Unauthorized(ErrorMessages.InvalidCredentials);

        var isPasswordValid = await userService.CheckPasswordAsync(user, password);
        if (!isPasswordValid) return AppError.Unauthorized(ErrorMessages.InvalidCredentials);

        foreach (var token in user.RefreshTokens.Where(rt => rt.IsActive))
        {
            token.IsRevoked = true;
            token.RevokedAt = DateTime.UtcNow;
        }

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshTokenWithPlain = tokenService.GenerateRefreshToken(user);

        unitOfWork.RefreshTokens.Add(refreshTokenWithPlain.TokenEntity);
        await unitOfWork.SaveChangesAsync();

        return new AuthResponseDto(accessToken, refreshTokenWithPlain.PlainToken);
    }

    public async Task<Result<AuthResponseDto>> RefreshTokenAsync(string refreshToken)
    {
        var hashedToken = TokenHashing.ComputeHash(refreshToken);

        var token = await refreshTokenRepository.GetByTokenAsync(hashedToken);

        if (token is null) return AppError.Unauthorized(ErrorMessages.InvalidRefreshToken);
        if (!token.IsActive) return AppError.Unauthorized(ErrorMessages.InvalidOrExpiredRefreshToken);

        token.IsRevoked = true;
        token.RevokedAt = DateTime.UtcNow;

        var newRefreshTokenWithPlain = tokenService.GenerateRefreshToken(token.User);

        token.ReplacedByToken = newRefreshTokenWithPlain.TokenEntity.Token;
        unitOfWork.RefreshTokens.Add(newRefreshTokenWithPlain.TokenEntity);

        var newAccessToken = tokenService.GenerateAccessToken(token.User);

        await unitOfWork.SaveChangesAsync();

        return new AuthResponseDto(newAccessToken, newRefreshTokenWithPlain.PlainToken);
    }

    public async Task<Result<AuthResponseDto>> SignUpAsync(SignUpRequestDto model)
    {
        var existingUser = await userService.FindByEmailAsync(model.Email);
        if (existingUser is not null) return AppError.Conflict(ErrorMessages.EmailAlreadyExists);

        var user = mapper.Map<AppUser>(model);

        var creationResult = await userService.CreateUserAsync(user, model.Password);
        if (!creationResult.Succeeded) return AppError.Validation(ErrorMessages.UserCreationFailed);

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshTokenWithPlain = tokenService.GenerateRefreshToken(user);

        unitOfWork.RefreshTokens.Add(refreshTokenWithPlain.TokenEntity);
        await unitOfWork.SaveChangesAsync();

        return new AuthResponseDto(accessToken, refreshTokenWithPlain.PlainToken);
    }
}