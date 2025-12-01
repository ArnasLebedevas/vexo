using RazorLight;
using RazorLight.Compilation;
using Vexo.Application.Common.Exceptions;
using Vexo.Application.Interfaces.Messaging;

namespace Vexo.Infrastructure.Email;

public sealed class EmailTemplateRenderer : IEmailTemplateRenderer
{
    private readonly RazorLightEngine _engine;

    public EmailTemplateRenderer()
    {
        _engine = new RazorLightEngineBuilder()
            .UseEmbeddedResourcesProject(typeof(EmailTemplateRenderer))
            .UseMemoryCachingProvider()
            .Build();
    }

    public Task<string> RenderAsync<TModel>(string templateKey, TModel model) 
    {
        try
        {
            return _engine.CompileRenderAsync(templateKey, model);
        }
        catch (TemplateCompilationException exception)
        {
            throw new EmailTemplateRenderException(templateKey, exception);
        }
        catch (TemplateNotFoundException exception)
        {
            throw new EmailTemplateRenderException(templateKey, exception);
        }
    }
}