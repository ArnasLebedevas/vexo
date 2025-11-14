using Vexo.Domain.Enums;

namespace Vexo.Domain.Entities;

public class Coin : IBaseEntity
{
    public Guid Id { get; set; }

    public required string Symbol { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }

    public DateTime ListedAt { get; set; } = DateTime.UtcNow;
    public CoinStatus Status { get; set; } = CoinStatus.Draft;
}
