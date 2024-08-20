using MongoDB.Bson.Serialization.Attributes;

namespace UtilityBilling.Domain.Common;

public class BaseEntity
{
    [BsonId]
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; }
}