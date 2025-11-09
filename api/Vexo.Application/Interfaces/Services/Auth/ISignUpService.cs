using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;

namespace Vexo.Application.Interfaces.Services.Auth;

public interface ISignUpService
{
    Task<Result<AuthResponseDto>> SignUpAsync(SignUpRequestDto model);
}
