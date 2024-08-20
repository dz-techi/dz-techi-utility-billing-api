using AspNetCoreCleanArchitecture.Domain.Common;

namespace AspNetCoreCleanArchitecture.Domain.Models;

public class ProductDto : BaseEntity
{
    public string Name { get; set; } = null!;
}