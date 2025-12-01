using Microsoft.AspNetCore.Identity;

namespace Vexo.Domain.Entities;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public string? AvatarUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }

    public List<RefreshToken> RefreshTokens { get; set; } = [];

    public static User Create(string email) => new()
    {
        Email = email,
        UserName = email
    };

    public void MarkEmailConfirmed() => EmailConfirmed = true;
    
    public void RevokeAllActiveTokens()
    {
        foreach (var token in RefreshTokens.Where(rt => rt.IsActive))
            token.RevokeActiveToken();
    }
}
