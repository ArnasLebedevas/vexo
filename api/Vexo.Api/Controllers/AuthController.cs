using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vexo.Application.Features.Auth.Commands.RequestLoginCode;
using Vexo.Application.Features.Auth.Commands.Token;
using Vexo.Application.Features.Auth.Commands.VerifyLoginCode;

namespace Vexo.Api.Controllers;

[Route("api/auth")]
public class AuthController(IMediator mediator) : BaseApiController
{
    [HttpPost("request-login-code")]
    public async Task<IActionResult> RequestLoginCode([FromBody] RequestLoginCodeCommand command) => HandleResponse(await mediator.Send(command));

    [HttpGet("verify-login-code")]
    public async Task<IActionResult> VerifyLoginCode([FromQuery] VerifyLoginCodeCommand command) => HandleResponse(await mediator.Send(command));

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command) => HandleResponse(await mediator.Send(command));
}