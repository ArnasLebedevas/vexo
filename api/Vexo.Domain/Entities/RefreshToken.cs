namespace Vexo.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public required string Token { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public required Guid AppUserId { get; set; }
    public required AppUser AppUser { get; set; }

    public DateTime? RevokedAt { get; set; }
    public string? ReplacedByToken { get; set; }

    public bool IsActive => !IsRevoked && DateTime.UtcNow < ExpiresAt;
}