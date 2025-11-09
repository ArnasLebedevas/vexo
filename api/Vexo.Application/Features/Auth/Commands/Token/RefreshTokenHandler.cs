using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services.Auth;

namespace Vexo.Application.Features.Auth.Commands.Token;

internal sealed class RefreshTokenHandler(IRefreshTokenService refreshTokenService) : ICommandHandler<RefreshTokenCommand, AuthResponseDto>
{
    public Task<Result<AuthResponseDto>> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        return refreshTokenService.RefreshTokenAsync(command.RefreshToken);
    }
}