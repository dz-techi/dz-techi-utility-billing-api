using UtilityBilling.Api.Services.Interfaces;

namespace UtilityBilling.Api.Extensions;

public static class DataSeedingExtension
{
    public static WebApplication SeedData(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        
        var provider = scope.ServiceProvider;

        var dataSeedingService = provider.GetService<IDataSeedingService>() ?? throw new NullReferenceException();

        dataSeedingService.SeedTestingData();

        return webApplication;
    }
}