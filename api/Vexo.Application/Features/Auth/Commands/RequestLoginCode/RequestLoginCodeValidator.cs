using FluentValidation;
using Vexo.Application.Common.Messages;

namespace Vexo.Application.Features.Auth.Commands.RequestLoginCode;

public sealed class RequestLoginCodeValidator : AbstractValidator<RequestLoginCodeCommand>
{
    public RequestLoginCodeValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty().WithMessage(ValidationMessages.EmailRequired)
           .EmailAddress().WithMessage(ValidationMessages.EmailInvalidFormat);
    }
}