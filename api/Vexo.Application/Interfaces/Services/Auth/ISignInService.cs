using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;

namespace Vexo.Application.Interfaces.Services.Auth;

public interface ISignInService
{
    Task<Result<AuthResponseDto>> SignInAsync(string email, string password);
    Task<Result<AuthResponseDto>> GoogleSignInAsync(string idToken);
}
