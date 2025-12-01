namespace Vexo.Application.Interfaces.Services;

public interface IUrlBuilderService
{
    string BuildPasswordlessLoginUrl(string email, string code);
}
