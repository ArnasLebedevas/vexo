using FluentValidation;
using Vexo.Application.Common.Messages;

namespace Vexo.Application.Features.Auth.SignUp;

internal class SignUpValidator : AbstractValidator<SignUpCommand>
{
    public SignUpValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty().MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(ValidationMessages.EmailRequired)
            .EmailAddress().WithMessage(ValidationMessages.EmailInvalidFormat);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(ValidationMessages.PasswordRequired)
            .MinimumLength(8).WithMessage(ValidationMessages.PasswordLength);
    }
}