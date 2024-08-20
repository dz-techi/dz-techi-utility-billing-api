using AspNetCoreCleanArchitecture.Contracts.Results.Product;
using AspNetCoreCleanArchitecture.Domain.Models;
using Mapster;

namespace AspNetCoreCleanArchitecture.Application.Mappings;

public class ProductMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductDto, GetProductResult>();
    }
}