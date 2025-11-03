using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services;

namespace Vexo.Application.Features.Auth.Token;

internal sealed class RefreshTokenHandler(IAuthService authService) : ICommandHandler<RefreshTokenCommand, AuthResponseDto>
{
    public async Task<Result<AuthResponseDto>> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        return await authService.RefreshTokenAsync(command.RefreshToken);
    }
}