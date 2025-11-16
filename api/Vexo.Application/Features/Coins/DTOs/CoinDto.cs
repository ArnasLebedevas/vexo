namespace Vexo.Application.Features.Coins.DTOs;

public record CoinDto(
    Guid Id,
    string Symbol,
    string Name,
    string? LogoUrl,
    string? Blockchain,
    string? Network
);