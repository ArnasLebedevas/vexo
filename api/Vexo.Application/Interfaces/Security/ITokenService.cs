using Vexo.Application.Features.Auth.DTOs;
using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Security;

public interface ITokenService
{
    string GenerateAccessToken(AppUser user);
    RefreshTokenWithPlain GenerateRefreshToken(AppUser user);
    bool ValidateRefreshTokenHashed(AppUser user, string refreshToken);
}
