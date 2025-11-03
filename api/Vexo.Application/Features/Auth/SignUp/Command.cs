using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;

namespace Vexo.Application.Features.Auth.SignUp;

public sealed record SignUpCommand(string Email, string Password, string FirstName, string LastName) : ICommand<AuthResponseDto>;