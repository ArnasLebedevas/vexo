using MediatR;
using Vexo.Application.Interfaces.CQRS;

namespace Vexo.Application.Features.Auth.Commands.ResendConfirmationEmail;

public sealed record ResendConfirmationEmailCommand(Guid UserId) : ICommand<Unit>;
