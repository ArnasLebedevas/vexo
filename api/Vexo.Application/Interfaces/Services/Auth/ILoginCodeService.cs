using MediatR;
using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;

namespace Vexo.Application.Interfaces.Services.Auth;

public interface ILoginCodeService
{
    Task<Result<Unit>> RequestLoginCodeAsync(string email);
    Task<Result<AuthResponseDto>> VerifyLoginCodeAsync(string email, string inputCode);
}
