using MediatR;
using Vexo.Application.Interfaces.CQRS;

namespace Vexo.Application.Features.Auth.Commands.RequestLoginCode;

public sealed record RequestLoginCodeCommand(string Email) : ICommand<Unit>;