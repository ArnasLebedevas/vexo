using Vexo.Application.Common;
using Vexo.Application.Common.Errors;
using Vexo.Application.Common.Messages;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services;

namespace Vexo.Application.Features.Auth.SignIn;

public sealed class SignInHandler(IAuthService authService) : ICommandHandler<SignInCommand, AuthResponseDto>
{
    public async Task<Result<AuthResponseDto>> Handle(SignInCommand command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(command.Email) || string.IsNullOrWhiteSpace(command.Password))
            return AppError.Validation(ErrorMessages.MissingEmailOrPassword);

        return await authService.SignInAsync(command.Email, command.Password);
    }
}
