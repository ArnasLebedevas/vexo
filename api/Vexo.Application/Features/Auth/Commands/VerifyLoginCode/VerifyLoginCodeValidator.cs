using FluentValidation;
using Vexo.Application.Common.Messages;

namespace Vexo.Application.Features.Auth.Commands.VerifyLoginCode;

internal sealed class VerifyLoginCodeValidator : AbstractValidator<VerifyLoginCodeCommand>
{
    public VerifyLoginCodeValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty().WithMessage(ValidationMessages.EmailRequired)
           .EmailAddress().WithMessage(ValidationMessages.EmailInvalidFormat);

        RuleFor(x => x.Code)
          .NotEmpty().WithMessage(ValidationMessages.CodeRequired);
    }
}