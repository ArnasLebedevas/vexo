namespace Vexo.Api.DependencyInjection.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
        services
               .AddMediator()
               .AddMapper()
               .AddSettings(configuration)
               .AddApplicationServices();
}