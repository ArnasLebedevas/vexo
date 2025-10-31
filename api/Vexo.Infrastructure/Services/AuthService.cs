using Vexo.Application.Common;
using Vexo.Application.Common.Errors;
using Vexo.Application.Common.Messages;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.Repositories;
using Vexo.Application.Interfaces.Security;
using Vexo.Application.Interfaces.Services;

namespace Vexo.Infrastructure.Services;

public class AuthService(IUserService userService, ITokenService tokenService, IUnitOfWork unitOfWork) : IAuthService
{
    public async Task<Result<AuthResponseDto>> SignInAsync(string email, string password)
    {
        var user = await userService.FindByEmailAsync(email);
        if (user is null) return AppError.Unauthorized(ErrorMessages.InvalidCredentials);

        if (!await userService.CheckPasswordAsync(user, password))
            return AppError.Unauthorized(ErrorMessages.InvalidCredentials);

        foreach (var token in user.RefreshTokens.Where(t => t.IsActive))
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
}