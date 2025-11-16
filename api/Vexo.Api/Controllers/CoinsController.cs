using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vexo.Application.Features.Coins.Queries.GetCoins;

namespace Vexo.Api.Controllers;

[Route("api/coins")]
public class CoinsController(IMediator mediator) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetCoins([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100) => 
        HandleResponse(await mediator.Send(new GetCoinsQuery(pageNumber, pageSize)));
}
