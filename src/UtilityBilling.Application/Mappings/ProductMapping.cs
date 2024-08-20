using UtilityBilling.Contracts.Results.Product;
using UtilityBilling.Domain.Models;
using Mapster;

namespace UtilityBilling.Application.Mappings;

public class ProductMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductDto, GetProductResult>();
    }
}