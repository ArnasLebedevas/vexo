using Vexo.Application.Common.Errors;

namespace Vexo.Application.Common.Exceptions;

public static class ExceptionMapper
{
    public static Result<object> Map(Exception exception)
    {
        return exception switch
        {
            ValidationException ex => Result<object>.Failure(
                AppError.Validation(ex.Message),
                ErrorType.Validation,
                ex.Errors?.ToDictionary(error => error.Key, error => error.Value)
            ),
            BadRequestException ex => Result<object>.Failure(
              AppError.BadRequest(ex.Message),
              ErrorType.BadRequest
            ),
            UnauthorizedAccessException ex => Result<object>.Failure(
                AppError.Unauthorized(ex.Message),
                ErrorType.Unauthorized
            ),
            NotFoundException ex => Result<object>.Failure(
                AppError.NotFound(ex.Message),
                ErrorType.NotFound
            ),
            _ => Result<object>.Failure(AppError.System, ErrorType.System)
        };
    }
}