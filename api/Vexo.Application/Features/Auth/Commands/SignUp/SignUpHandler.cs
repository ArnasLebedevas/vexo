using AutoMapper;
using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services.Auth;

namespace Vexo.Application.Features.Auth.Commands.SignUp;

internal sealed class SignUpHandler(ISignUpService signUpService, IMapper mapper) : ICommandHandler<SignUpCommand, AuthResponseDto>
{
    public Task<Result<AuthResponseDto>> Handle(SignUpCommand command, CancellationToken cancellationToken)
    {
        return signUpService.SignUpAsync(mapper.Map<SignUpRequestDto>(command));
    }
}
