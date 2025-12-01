namespace Vexo.Domain.Entities;

public class LoginCode : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public required string Code { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool Used { get; set; }

    public static LoginCode Create(Guid userId, string code, int minutes) => new()
    {
        Id = Guid.NewGuid(),
        UserId = userId,
        Code = code,
        ExpiresAt = DateTime.UtcNow.AddMinutes(minutes),
        Used = false
    };

    public void MarkAsUsed() => Used = true;

    public bool IsValid() => !Used && DateTime.UtcNow < ExpiresAt;
}