using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vexo.Application.Interfaces.Repositories;
using Vexo.Application.Interfaces.Repositories.Read;
using Vexo.Application.Interfaces.Repositories.Write;
using Vexo.Persistence.Repositories;
using Vexo.Persistence.Repositories.Read;
using Vexo.Persistence.Repositories.Write;

namespace Vexo.Persistence.Registrations;

internal static class RepositoryRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}