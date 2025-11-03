using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Vexo.Application.Common.Settings;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.Security;
using Vexo.Domain.Entities;

namespace Vexo.Infrastructure.Services.Security;

public class TokenService(IOptions<JwtSettings> options) : ITokenService
{
    private readonly JwtSettings _jwtSettings = options.Value;

    public string GenerateAccessToken(AppUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public RefreshTokenWithPlain GenerateRefreshToken(AppUser user)
    {
        var randomBytes = RandomNumberGenerator.GetBytes(64);
        var plainToken = Convert.ToBase64String(randomBytes);

        var hashedToken = TokenHashing.ComputeHash(plainToken);

        var refreshToken = new RefreshToken
        {
            Token = hashedToken,
            ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays),
            CreatedAt = DateTime.UtcNow,
            IsRevoked = false,
            UserId = user.Id,
            User = user,
        };

        return new RefreshTokenWithPlain(refreshToken, plainToken);
    }

    public bool ValidateRefreshTokenHashed(AppUser user, string hashedToken)
    {
        var token = user.RefreshTokens.FirstOrDefault(rt => rt.Token == hashedToken);
        return token is not null && token.IsActive;
    }
}
