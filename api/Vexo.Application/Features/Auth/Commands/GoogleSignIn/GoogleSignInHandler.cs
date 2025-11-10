using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services.Auth;

namespace Vexo.Application.Features.Auth.Commands.GoogleSignIn;

internal sealed class GoogleSignInHandler(ISignInService signInService) : ICommandHandler<GoogleSignInCommand, AuthResponseDto>
{
    public Task<Result<AuthResponseDto>> Handle(GoogleSignInCommand command, CancellationToken cancellationToken)
    {
        return signInService.GoogleSignInAsync(command.IdToken);
    }
}
