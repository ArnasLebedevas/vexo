using MediatR;
using Vexo.Application.Common;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services.Auth;

namespace Vexo.Application.Features.Auth.Commands.ConfirmEmail;

internal sealed class ConfirmEmailHandler(IEmailService confirmEmailService) : ICommandHandler<ConfirmEmailCommand, Unit>
{
    public Task<Result<Unit>> Handle(ConfirmEmailCommand command, CancellationToken cancellationToken)
    {
        return confirmEmailService.ConfirmEmailAsync(command.UserId, command.Token);
    }
}
