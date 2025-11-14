using Microsoft.AspNetCore.Identity;
using Vexo.Domain.Entities;
using Vexo.Persistence;

namespace Vexo.Api.DependencyInjection.Infrastructure;

internal static class IdentityRegistration
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 10;
            options.Password.RequiredUniqueChars = 4;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<VexoDbContext>().AddDefaultTokenProviders();


        return services;
    }
}
