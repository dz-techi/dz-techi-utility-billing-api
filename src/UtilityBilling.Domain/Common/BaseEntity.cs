using MongoDB.Bson.Serialization.Attributes;

namespace UtilityBilling.Domain.Common;

public abstract class BaseEntity
{
    [BsonId]
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; }
    
    public DateTime UpdatedDate { get; set; }

    protected BaseEntity()
    {
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }
}