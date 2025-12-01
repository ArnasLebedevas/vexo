namespace Vexo.Application.Common.Messages;

public static class ErrorMessages
{
    public const string UnexpectedError = "An unexpected error occurred.";
    public const string ValidationFailed = "Validation failed.";
    public const string MissingJWT = "JWT Secret is missing in configuration.";
    public const string InvalidCredentials = "Invalid credentials.";
    public const string InvalidRefreshToken = "Invalid refresh token.";
    public const string InvalidOrExpiredRefreshToken = "Invalid or expired refresh token.";
    public const string InvalidOrExpiredLoginCode = "Invalid or expired login code.";

    public static string NotFound(string entity) => $"{entity} was not found.";
}