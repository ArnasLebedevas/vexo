using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vexo.Application.Features.Auth.SignIn;
using Vexo.Application.Features.Auth.SignUp;
using Vexo.Application.Features.Auth.Token;

namespace Vexo.Api.Controllers;

[Route("api/auth")]
public class AuthController(IMediator mediator) : BaseApiController
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand command) => HandleResponse(await mediator.Send(command));

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command) => HandleResponse(await mediator.Send(command));

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command) => HandleResponse(await mediator.Send(command));
}