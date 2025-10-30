﻿namespace Vexo.Application.Common.Errors;

public sealed class AppError(ErrorType code, string message)
{
    public string Code { get; } = code.ToString();
    public string Message { get; } = message;

    public static AppError System => new(ErrorType.System, "An unexpected error occurred.");
    public static AppError NotFound(string entity) => new(ErrorType.NotFound, $"{entity} was not found.");
    public static AppError Validation(string message) => new(ErrorType.Validation, message);
    public static AppError Conflict(string message) => new(ErrorType.Conflict, message);
    public static AppError Email(string message) => new(ErrorType.Email, message);
    public static AppError Unauthorized(string message) => new(ErrorType.Unauthorized, message);
    public static AppError UnsupportedProvider(string message) => new(ErrorType.UnsupportedProvider, message);
}