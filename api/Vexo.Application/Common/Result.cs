using Vexo.Application.Common.Errors;

namespace Vexo.Application.Common;

public sealed record Result<T>(bool IsSuccess, T? Data,AppError? Error, ErrorType ErrorType, Dictionary<string, string[]>? Errors)
{
    public static Result<T> Success(T data) => new(true, data, null, ErrorType.None, null);
    public static Result<T> Failure(AppError error, ErrorType type = ErrorType.Business, Dictionary<string, string[]>? errors = null) =>  new(false, default, error, type, errors);

    public static implicit operator Result<T>(T data) => Success(data);
    public static implicit operator Result<T>(AppError error) => Failure(error);
}