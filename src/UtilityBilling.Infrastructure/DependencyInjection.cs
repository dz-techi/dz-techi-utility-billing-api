using UtilityBilling.Infrastructure.Database;
using UtilityBilling.Infrastructure.Repositories;
using UtilityBilling.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace UtilityBilling.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IAppDbContext, AppDbContext>();

        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}