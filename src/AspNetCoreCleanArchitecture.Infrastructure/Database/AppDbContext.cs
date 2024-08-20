using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace AspNetCoreCleanArchitecture.Infrastructure.Database;

public class AppDbContext : IAppDbContext
{
    public IMongoDatabase Database { get; set; }
    
    public AppDbContext(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        
        Database = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
        
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return Database.GetCollection<T>(collectionName);
    }
}