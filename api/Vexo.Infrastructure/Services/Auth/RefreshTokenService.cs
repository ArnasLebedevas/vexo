using Vexo.Application.Common;
using Vexo.Application.Common.Errors;
using Vexo.Application.Common.Messages;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.Repositories;
using Vexo.Application.Interfaces.Repositories.Read;
using Vexo.Application.Interfaces.Security;
using Vexo.Application.Interfaces.Services.Auth;
using Vexo.Infrastructure.Services.Security;

namespace Vexo.Infrastructure.Services.Auth;

internal sealed class RefreshTokenService(
    IRefreshTokenReadRepository refreshTokenRepository,
    ITokenService tokenService,
    IUnitOfWork unitOfWork) : IRefreshTokenService
{
    public async Task<Result<AuthResponseDto>> RefreshTokenAsync(string refreshToken)
    {
        var hashedToken = TokenHashing.ComputeHash(refreshToken);

        var token = await refreshTokenRepository.GetByTokenAsync(hashedToken);

        if (token is null) return AppError.Unauthorized(ErrorMessages.InvalidRefreshToken);
        if (!token.IsActive) return AppError.Unauthorized(ErrorMessages.InvalidOrExpiredRefreshToken);

        token.RevokeActiveToken();

        var newRefreshTokenWithPlain = tokenService.GenerateRefreshToken(token.User);

        token.ReplacedByToken = newRefreshTokenWithPlain.TokenEntity.Token;
        unitOfWork.RefreshTokens.Add(newRefreshTokenWithPlain.TokenEntity);

        var newAccessToken = tokenService.GenerateAccessToken(token.User);

        await unitOfWork.SaveChangesAsync();

        return new AuthResponseDto(newAccessToken, newRefreshTokenWithPlain.PlainToken);
    }
}