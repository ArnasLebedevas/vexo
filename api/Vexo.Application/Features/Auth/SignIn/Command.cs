namespace Vexo.Application.Features.Auth.SignIn;

public sealed record SignInCommand(string Email, string Password) : ICommand<AuthResponseDto>;