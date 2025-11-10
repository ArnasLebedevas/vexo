using MediatR;
using Vexo.Application.Common;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services.Auth;

namespace Vexo.Application.Features.Auth.Commands.ResendConfirmationEmail;

internal class ResendConfirmationEmailHandler(IEmailService confirmEmailService) : ICommandHandler<ResendConfirmationEmailCommand, Unit>
{
    public Task<Result<Unit>> Handle(ResendConfirmationEmailCommand command, CancellationToken cancellationToken)
    {
        return confirmEmailService.ResendConfirmationEmailAsync(command.UserId);
    }
}
