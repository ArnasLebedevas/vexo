using FluentValidation;
using MediatR;
using Vexo.Application.Common.Behaviors;
using Vexo.Application.Features.Auth.Commands.SignIn;

namespace Vexo.Api.DependencyInjection.Application;

internal static class MediatorRegistration
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SignInCommand).Assembly));
        services.AddValidatorsFromAssemblyContaining<SignInValidator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}