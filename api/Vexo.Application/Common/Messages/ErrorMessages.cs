namespace Vexo.Application.Common.Messages;

public static class ErrorMessages
{
    public const string UnexpectedError = "An unexpected error occurred.";
    public const string ValidationFailed = "Validation failed.";
    public const string MissingJWT = "JWT Secret is missing in configuration.";
    public const string InvalidCredentials = "Invalid credentials.";
    public const string InvalidRefreshToken = "Invalid refresh token.";
    public const string InvalidOrExpiredRefreshToken = "Invalid or expired refresh token.";
    public const string EmailAlreadyExists = "Email already exists.";
    public const string UserCreationFailed = "User creation failed.";
    public const string InvalidGoogleToken = "Invalid Google token.";
    public const string UserNotFound = "User not found.";
    public const string InvalidEmailConfirmationToken = "Invalid email confirmation token.";
    public const string EmailAlreadyConfirmed = "Email is already confirmed.";
    public const string EmailNotConfirmed = "Email is not confirmed.";

    public static string NotFound(string entity) => $"{entity} was not found.";
}