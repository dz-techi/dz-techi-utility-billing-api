using UtilityBilling.Domain.Common;

namespace UtilityBilling.Domain.Models;

public class ProductDto : BaseEntity
{
    public string Name { get; set; } = null!;
}