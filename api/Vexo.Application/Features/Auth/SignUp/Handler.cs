using AutoMapper;
using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services;

namespace Vexo.Application.Features.Auth.SignUp;

internal sealed class SignUpHandler(IAuthService authService, IMapper mapper) : ICommandHandler<SignUpCommand, AuthResponseDto>
{
    public async Task<Result<AuthResponseDto>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        return await authService.SignUpAsync(mapper.Map<SignUpRequestDto>(request));
    }
}
