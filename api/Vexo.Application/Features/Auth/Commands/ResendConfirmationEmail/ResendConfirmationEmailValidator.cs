using FluentValidation;
using Vexo.Application.Common.Messages;

namespace Vexo.Application.Features.Auth.Commands.ResendConfirmationEmail;

internal sealed class ResendConfirmationEmailValidator : AbstractValidator<ResendConfirmationEmailCommand>
{
    public ResendConfirmationEmailValidator()
    {
        RuleFor(x => x.UserId)
           .NotEmpty().WithMessage(ValidationMessages.UserIdRequired);
    }
}
