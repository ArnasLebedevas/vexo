using System.Security.Cryptography;
using System.Text;

namespace Vexo.Infrastructure.Services.Security;

public static class TokenHashing
{
    public static string ComputeHash(string token)
    {
        var bytes = Encoding.UTF8.GetBytes(token);
        var hash = SHA256.HashData(bytes);
        return Convert.ToHexString(hash);
    }
}