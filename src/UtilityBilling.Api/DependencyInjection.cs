using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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

        services.AddCors();
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Authority = "https://dev-7yg7bk42kt1hapxi.us.auth0.com/";
            options.Audience = "http://localhost:5299";

            // options.TokenValidationParameters = new TokenValidationParameters
            // {
            //     ValidateAudience = false,
            //     ValidateIssuer = false, // Temporarily disable issuer validation for debugging
            //     ValidateIssuerSigningKey = true,
            // };
            
            // options.Events = new JwtBearerEvents
            // {
            //     OnAuthenticationFailed = context =>
            //     {
            //         Console.WriteLine("Authentication failed: " + context.Exception.Message);
            //         return Task.CompletedTask;
            //     },
            //     OnTokenValidated = context =>
            //     {
            //         Console.WriteLine("Token validated: " + context.SecurityToken);
            //         return Task.CompletedTask;
            //     },
            //     OnChallenge = context =>
            //     {
            //         Console.WriteLine("OnChallenge error: " + context.Error + ", description: " + context.ErrorDescription);
            //         return Task.CompletedTask;
            //     }
            // };
        });

        services.AddAuthorization();

        return services;
    }
}