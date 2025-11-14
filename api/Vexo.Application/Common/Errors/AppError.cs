using Vexo.Application.Common.Messages;

namespace Vexo.Application.Common.Errors;

public sealed class AppError(ErrorType code, string message)
{
    public string Code { get; } = code.ToString();
    public string Message { get; } = message;

    public static AppError System => new(ErrorType.System, ErrorMessages.UnexpectedError);
    public static AppError NotFound(string entity) => new(ErrorType.NotFound, ErrorMessages.NotFound(entity));
    public static AppError Validation(string message) => new(ErrorType.Validation, message);
    public static AppError Conflict(string message) => new(ErrorType.Conflict, message);
    public static AppError Unauthorized(string message) => new(ErrorType.Unauthorized, message);
}