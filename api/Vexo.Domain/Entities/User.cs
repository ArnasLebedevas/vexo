using Microsoft.AspNetCore.Identity;

namespace Vexo.Domain.Entities;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? AvatarUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }

    public List<RefreshToken> RefreshTokens { get; set; } = [];

    public void RevokeAllActiveTokens()
    {
        foreach (var token in RefreshTokens.Where(rt => rt.IsActive))
        {
            token.IsRevoked = true;
            token.RevokedAt = DateTime.UtcNow;
        }
    }
}
