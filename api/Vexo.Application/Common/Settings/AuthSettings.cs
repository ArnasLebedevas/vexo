namespace Vexo.Application.Common.Settings;

public class AuthSettings
{
    public required JwtSettings Jwt { get; set; }
    public required LoginCodeSettings LoginCode { get; set; }
}