using Vexo.Application.Common;
using Vexo.Application.Features.Auth.DTOs;

namespace Vexo.Application.Interfaces.Services;

public interface IAuthService
{
    Task<Result<AuthResponseDto>> SignInAsync(string email, string password);
    Task<Result<AuthResponseDto>> RefreshTokenAsync(string refreshToken);
    Task<Result<AuthResponseDto>> SignUpAsync(string email, string password, string firstName, string lastName);
}