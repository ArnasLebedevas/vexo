using Vexo.Application.Common.Errors;

namespace Vexo.Api.Middlewares;

internal static class HttpStatusMapper
{
    public static int Map(ErrorType errorType) => errorType switch
    {
        ErrorType.Validation => StatusCodes.Status400BadRequest,
        ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
        ErrorType.NotFound => StatusCodes.Status404NotFound,
        ErrorType.Email => StatusCodes.Status502BadGateway,
        ErrorType.UnsupportedProvider => StatusCodes.Status400BadRequest,
        _ => StatusCodes.Status500InternalServerError
    };
}