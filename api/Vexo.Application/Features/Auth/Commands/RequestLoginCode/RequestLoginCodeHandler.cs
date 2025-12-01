using MediatR;
using Vexo.Application.Common;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services.Auth;

namespace Vexo.Application.Features.Auth.Commands.RequestLoginCode;

internal class RequestLoginCodeHandler(ILoginCodeService loginCode) : ICommandHandler<RequestLoginCodeCommand, Unit>
{
    public Task<Result<Unit>> Handle(RequestLoginCodeCommand request, CancellationToken cancellationToken)
        => loginCode.RequestLoginCodeAsync(request.Email);
}
