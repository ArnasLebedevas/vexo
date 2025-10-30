using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vexo.Application.Features.Auth.SignIn;

namespace Vexo.Api.Controllers;

[Route("api/auth")]
public class AuthController(IMediator mediator) : BaseApiController
{
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command) => HandleResponse(await mediator.Send(command));
}
