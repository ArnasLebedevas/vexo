using FluentValidation;
using Vexo.Application.Common.Messages;

namespace Vexo.Application.Features.Auth.Commands.ConfirmEmail;

internal sealed class ConfirmEmailValidator : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage(ValidationMessages.TokenRequired);

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage(ValidationMessages.UserIdRequired);
    }
}
