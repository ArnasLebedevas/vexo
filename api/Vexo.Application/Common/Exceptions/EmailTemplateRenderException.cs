namespace Vexo.Application.Common.Exceptions;

public sealed class EmailTemplateRenderException(string template, Exception inner) 
    : Exception($"Failed to render email template '{template}'", inner) {}