using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Vexo.Application.Interfaces.Security;

namespace Vexo.Infrastructure.Security;

public sealed class UrlTokenEncoder : IUrlTokenEncoder
{
    public string Encode(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        return WebEncoders.Base64UrlEncode(bytes);
    }

    public string Decode(string encoded)
    {
        var bytes = WebEncoders.Base64UrlDecode(encoded);
        return Encoding.UTF8.GetString(bytes);
    }
}