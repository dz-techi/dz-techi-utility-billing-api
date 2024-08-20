using AspNetCoreCleanArchitecture.Api.Exceptions;
using AspNetCoreCleanArchitecture.Infrastructure.Database;

namespace AspNetCoreCleanArchitecture.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDB"));

        services.AddExceptionHandler<GlobalExceptionHandler>();
        
        return services;
    }
}