namespace Vexo.Application.Common.Messages;

public static class ErrorMessages
{
    public const string UnexpectedError = "An unexpected error occurred.";
    public const string ValidationFailed = "Validation failed.";
    public const string MissingJWT = "JWT Secret is missing in configuration.";
    public const string MissingEmailOrPassword = "Email and password are required.";
    public const string InvalidCredentials = "Invalid credentials.";

    public static string NotFound(string entity) => $"{entity} was not found.";
}