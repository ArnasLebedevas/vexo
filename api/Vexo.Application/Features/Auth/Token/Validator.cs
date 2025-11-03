using FluentValidation;
using Vexo.Application.Common.Messages;

namespace Vexo.Application.Features.Auth.Token;

internal class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty().WithMessage(ValidationMessages.RefreshTokenRequired);
    }
}