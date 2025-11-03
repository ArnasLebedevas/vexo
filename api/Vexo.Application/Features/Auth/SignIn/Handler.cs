using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services;

namespace Vexo.Application.Features.Auth.SignIn;

internal sealed class SignInHandler(IAuthService authService) : ICommandHandler<SignInCommand, AuthResponseDto>
{
    public async Task<Result<AuthResponseDto>> Handle(SignInCommand command, CancellationToken cancellationToken)
    {
        return await authService.SignInAsync(command.Email, command.Password);
    }
}