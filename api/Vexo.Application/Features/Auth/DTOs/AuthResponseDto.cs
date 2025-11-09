namespace Vexo.Application.Features.Auth.DTOs;

public sealed record AuthResponseDto(string Token, string RefreshToken);