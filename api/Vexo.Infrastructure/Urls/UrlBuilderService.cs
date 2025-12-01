using Microsoft.Extensions.Options;
using System.Web;
using Vexo.Application.Common.Settings;
using Vexo.Application.Interfaces.Services;

namespace Vexo.Infrastructure.Urls;

public sealed class UrlBuilderService(IOptions<AppSettings> options) : IUrlBuilderService
{
    private readonly AppSettings _app = options.Value;

    public string BuildPasswordlessLoginUrl(string email, string code)
        => $"{_app.BaseUrl}/api/auth/verify-login-code?" +
           $"email={HttpUtility.UrlEncode(email)}&" +
           $"code={HttpUtility.UrlEncode(code)}";
}