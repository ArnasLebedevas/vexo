using Vexo.Application.Interfaces.Repositories;
using Vexo.Application.Interfaces.Repositories.Read;
using Vexo.Application.Interfaces.Repositories.Write;
using Vexo.Persistence.Repositories;
using Vexo.Persistence.Repositories.Read;
using Vexo.Persistence.Repositories.Write;

namespace Vexo.Api.DependencyInjection.Persistence;

internal static class RepositoryRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRefreshTokenReadRepository, RefreshTokenReadRepository>();
        services.AddScoped<ICoinReadRepository, CoinReadRepository>();

        return services;
    }
}