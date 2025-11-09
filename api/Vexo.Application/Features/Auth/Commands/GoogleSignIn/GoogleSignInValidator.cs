using FluentValidation;
using Vexo.Application.Common.Messages;

namespace Vexo.Application.Features.Auth.Commands.GoogleSignIn;

internal sealed class GoogleSignInValidator : AbstractValidator<GoogleSignInCommand>
{
    public GoogleSignInValidator()
    {
        RuleFor(x => x.IdToken)
            .NotEmpty().WithMessage(ValidationMessages.IdTokenRequired);
    }
}