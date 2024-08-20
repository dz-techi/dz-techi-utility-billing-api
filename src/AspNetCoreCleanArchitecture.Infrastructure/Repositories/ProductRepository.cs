using AspNetCoreCleanArchitecture.Domain.Models;
using AspNetCoreCleanArchitecture.Infrastructure.Database;
using AspNetCoreCleanArchitecture.Infrastructure.Repositories.Interfaces;

namespace AspNetCoreCleanArchitecture.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<ProductDto>, IProductRepository
{
    protected override string CollectionName => "products";
    
    public ProductRepository(IAppDbContext appDbContext) : base(appDbContext)
    {
    }
}