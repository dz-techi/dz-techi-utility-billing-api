using UtilityBilling.Domain.Models;
using UtilityBilling.Infrastructure.Database;
using UtilityBilling.Infrastructure.Repositories.Interfaces;

namespace UtilityBilling.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<ProductDto>, IProductRepository
{
    protected override string CollectionName => "products";
    
    public ProductRepository(IAppDbContext appDbContext) : base(appDbContext)
    {
    }
}