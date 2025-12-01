using FluentValidation;
using Vexo.Application.Common.Messages;

namespace Vexo.Application.Features.Auth.Commands.Token;

internal sealed class RequestLoginCodeValidator : AbstractValidator<RefreshTokenCommand>
{
    public RequestLoginCodeValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty().WithMessage(ValidationMessages.RefreshTokenRequired);
    }
}