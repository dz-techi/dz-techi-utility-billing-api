using UtilityBilling.Api.Exceptions;
using UtilityBilling.Infrastructure.Database;

namespace UtilityBilling.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDB"));

        services.AddExceptionHandler<GlobalExceptionHandler>();
        
        return services;
    }
}