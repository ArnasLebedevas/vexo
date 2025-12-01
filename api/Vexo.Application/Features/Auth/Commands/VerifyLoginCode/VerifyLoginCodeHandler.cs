using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services.Auth;

namespace Vexo.Application.Features.Auth.Commands.VerifyLoginCode;

internal sealed class VerifyLoginCodeHandler(ILoginCodeService loginCodeService) : ICommandHandler<VerifyLoginCodeCommand, AuthResponseDto>
{
    public Task<Result<AuthResponseDto>> Handle(VerifyLoginCodeCommand request, CancellationToken cancellationToken)
        => loginCodeService.VerifyLoginCodeAsync(request.Email, request.Code);
}
