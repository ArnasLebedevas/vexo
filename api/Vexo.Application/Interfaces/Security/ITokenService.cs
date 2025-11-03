using Vexo.Application.Features.Auth.DTOs;
using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Security;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    RefreshTokenWithPlain GenerateRefreshToken(User user);
    bool ValidateRefreshTokenHashed(User user, string refreshToken);
}
