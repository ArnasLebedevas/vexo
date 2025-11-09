using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;

namespace Vexo.Application.Interfaces.Services.Auth;

public interface IRefreshTokenService
{
    Task<Result<AuthResponseDto>> RefreshTokenAsync(string refreshToken);
}
