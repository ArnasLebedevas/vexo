using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;

namespace Vexo.Application.Features.Auth.Commands.VerifyLoginCode;

public sealed record VerifyLoginCodeCommand(string Email, string Code) : ICommand<AuthResponseDto>;