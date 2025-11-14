using AutoMapper;
using Google.Apis.Auth;
using Vexo.Application.Common;
using Vexo.Application.Common.Errors;
using Vexo.Application.Common.Messages;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.Repositories;
using Vexo.Application.Interfaces.Security;
using Vexo.Application.Interfaces.Services;
using Vexo.Application.Interfaces.Services.Auth;
using Vexo.Domain.Entities;

namespace Vexo.Application.Services.Auth;

public sealed class SignInService(
    IUserService userService,
    ITokenService tokenService,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ISignInService
{
    public async Task<Result<AuthResponseDto>> SignInAsync(string email, string password)
    {
        var user = await userService.FindByEmailAsync(email);
        if (user is null) return AppError.Unauthorized(ErrorMessages.InvalidCredentials);

        if (!user.EmailConfirmed) return AppError.Unauthorized(ErrorMessages.InvalidCredentials);

        var isPasswordValid = await userService.CheckPasswordAsync(user, password);
        if (!isPasswordValid) return AppError.Unauthorized(ErrorMessages.InvalidCredentials);

        user.RevokeAllActiveTokens();

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshTokenWithPlain = tokenService.GenerateRefreshToken(user);

        unitOfWork.RefreshTokens.Add(refreshTokenWithPlain.TokenEntity);
        await unitOfWork.SaveChangesAsync();

        return new AuthResponseDto(accessToken, refreshTokenWithPlain.PlainToken);
    }

    public async Task<Result<AuthResponseDto>> GoogleSignInAsync(string idToken)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
        var googleUser = mapper.Map<GoogleUserDto>(payload);

        var user = await userService.FindByEmailAsync(googleUser.Email);
        if (user is null)
        {
            user = mapper.Map<User>(googleUser);
            await userService.CreateUserAsync(user);
            await unitOfWork.SaveChangesAsync();
        }

        user.RevokeAllActiveTokens();

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshTokenWithPlain = tokenService.GenerateRefreshToken(user);

        unitOfWork.RefreshTokens.Add(refreshTokenWithPlain.TokenEntity);
        await unitOfWork.SaveChangesAsync();

        return new AuthResponseDto(accessToken, refreshTokenWithPlain.PlainToken);
    }
}
