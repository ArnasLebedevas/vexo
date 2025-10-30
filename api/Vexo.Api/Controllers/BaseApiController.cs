using Microsoft.AspNetCore.Mvc;
using Vexo.Application.Common;
using Vexo.Application.Common.Errors;

namespace Vexo.Api.Controllers;

[ApiController]
public class BaseApiController : ControllerBase
{
    protected IActionResult HandleResponse<T>(Result<T> response)
    {
        if (response.IsSuccess) return Ok(response);

        return response.ErrorType switch
        {
            ErrorType.Validation => BadRequest(response),
            ErrorType.Unauthorized => Unauthorized(response),
            ErrorType.NotFound => NotFound(response),
            ErrorType.Conflict => Conflict(response),
            ErrorType.Business => BadRequest(response),
            _ => StatusCode(500, response)
        };
    }
}
