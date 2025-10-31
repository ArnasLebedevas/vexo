namespace Vexo.Infrastructure.Services.Security;

public static class TokenHashing
{
    public static string ComputeHash(string token)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(token);
        var hash = System.Security.Cryptography.SHA256.HashData(bytes);
        return Convert.ToHexString(hash);
    }
}