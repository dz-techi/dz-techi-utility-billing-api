using AspNetCoreCleanArchitecture.Infrastructure.Database;
using AspNetCoreCleanArchitecture.Infrastructure.Repositories;
using AspNetCoreCleanArchitecture.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreCleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IAppDbContext, AppDbContext>();

        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}