namespace Vexo.Domain.Entities;

public class RefreshToken : IBaseEntity
{
    public Guid Id { get; set; }

    public required string Token { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public required Guid UserId { get; set; }
    public required AppUser User { get; set; }

    public DateTime? RevokedAt { get; set; }
    public string? ReplacedByToken { get; set; }

    public bool IsActive => !IsRevoked && DateTime.UtcNow < ExpiresAt;
}