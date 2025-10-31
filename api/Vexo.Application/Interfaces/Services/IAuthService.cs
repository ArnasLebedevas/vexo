using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;

namespace Vexo.Application.Interfaces.Services;

public interface IAuthService
{
    Task<Result<AuthResponseDto>> SignInAsync(string email, string password);
}