using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services.Auth;

namespace Vexo.Application.Features.Auth.Commands.SignIn;

internal sealed class SignInHandler(ISignInService signInService) : ICommandHandler<SignInCommand, AuthResponseDto>
{
    public Task<Result<AuthResponseDto>> Handle(SignInCommand command, CancellationToken cancellationToken)
    {
        return signInService.SignInAsync(command.Email, command.Password);
    }
}