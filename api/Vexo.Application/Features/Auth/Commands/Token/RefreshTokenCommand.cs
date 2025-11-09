using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;

namespace Vexo.Application.Features.Auth.Commands.Token;

public sealed record RefreshTokenCommand(string RefreshToken) : ICommand<AuthResponseDto>;