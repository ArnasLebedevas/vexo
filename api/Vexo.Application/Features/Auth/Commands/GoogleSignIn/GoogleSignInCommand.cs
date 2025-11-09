using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.CQRS;

namespace Vexo.Application.Features.Auth.Commands.GoogleSignIn;

public sealed record GoogleSignInCommand(string IdToken) : ICommand<AuthResponseDto>;