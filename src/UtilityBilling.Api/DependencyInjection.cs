using UtilityBilling.Api.Exceptions;
using UtilityBilling.Api.Services;
using UtilityBilling.Api.Services.Interfaces;
using UtilityBilling.Infrastructure.Database;

namespace UtilityBilling.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDB"));

        services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddScoped<IDataSeedingService, DataSeedingService>();
        
        return services;
    }
}