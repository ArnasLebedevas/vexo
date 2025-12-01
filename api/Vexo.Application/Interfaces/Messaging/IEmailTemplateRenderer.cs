namespace Vexo.Application.Interfaces.Messaging;

public interface IEmailTemplateRenderer
{
    Task<string> RenderAsync<T>(string templatePath, T model);
}
