using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Vexo.Application.Common.Behaviors;
using Vexo.Application.Features.Auth.Commands.SignIn;

namespace Vexo.Application.Registrations;

internal static class MediatRRegistration
{
    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SignInCommand).Assembly));
        services.AddValidatorsFromAssemblyContaining<SignInValidator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}