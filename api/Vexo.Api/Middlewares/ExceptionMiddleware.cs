using System.Text.Json;
using Vexo.Application.Common.Exceptions;

namespace Vexo.Api.Middlewares;

internal class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private static readonly JsonSerializerOptions CachedJsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);

            var result = ExceptionMapper.Map(ex);
            var statusCode = HttpStatusMapper.Map(result.ErrorType);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var json = JsonSerializer.Serialize(result, CachedJsonSerializerOptions);
            await context.Response.WriteAsync(json);
        }
    }
}