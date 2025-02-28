using UtilityBilling.Domain.Common;
using UtilityBilling.Infrastructure.Database;
using UtilityBilling.Infrastructure.Repositories.Interfaces;
using MongoDB.Driver;

namespace UtilityBilling.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private IAppDbContext AppDbContext { get; }

    protected IMongoCollection<T> Collection => AppDbContext.GetCollection<T>(CollectionName);

    protected abstract string CollectionName { get; }    
    
    protected BaseRepository(IAppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq(e => e.Id, id);

        return await Collection.Find(filter).SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entityDto, CancellationToken cancellationToken)
    {
        if (entityDto.Id == Guid.Empty)
        {
            entityDto.Id = Guid.NewGuid();
        }
        
        entityDto.CreatedDate = DateTime.UtcNow;
        
        await Collection.InsertOneAsync(entityDto, cancellationToken: cancellationToken);

        return entityDto;
    }

    public async Task<T> UpsertAsync(T entityDto, CancellationToken cancellationToken)
    {
        await Collection.ReplaceOneAsync(
            Builders<T>.Filter.Eq(e => e.Id, entityDto.Id),
            entityDto,
            new ReplaceOptions { IsUpsert = true },
            cancellationToken);

        return entityDto;
    }
    
    public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq(e => e.Id, id);

        var result = await Collection.DeleteOneAsync(filter, cancellationToken);

        return result.DeletedCount > 0;
    }
}