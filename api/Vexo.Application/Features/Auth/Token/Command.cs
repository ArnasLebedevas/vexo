using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;

namespace Vexo.Application.Features.Auth.Token;

public record RefreshTokenCommand(string RefreshToken) : ICommand<AuthResponseDto>;