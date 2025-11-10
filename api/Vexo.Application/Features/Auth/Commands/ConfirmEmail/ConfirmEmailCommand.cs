using MediatR;
using Vexo.Application.Interfaces.CQRS;

namespace Vexo.Application.Features.Auth.Commands.ConfirmEmail;

public sealed record ConfirmEmailCommand(Guid UserId, string Token) : ICommand<Unit>;