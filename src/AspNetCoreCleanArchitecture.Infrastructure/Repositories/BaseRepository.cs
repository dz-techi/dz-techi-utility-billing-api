using AspNetCoreCleanArchitecture.Domain.Common;
using AspNetCoreCleanArchitecture.Infrastructure.Database;
using AspNetCoreCleanArchitecture.Infrastructure.Repositories.Interfaces;
using MongoDB.Driver;

namespace AspNetCoreCleanArchitecture.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private IAppDbContext AppDbContext { get; }

    private IMongoCollection<T> Collection => AppDbContext.GetCollection<T>(CollectionName);

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

    public async Task<T?> AddAsync(T entityDto, CancellationToken cancellationToken)
    {
        if (entityDto.Id == Guid.Empty)
        {
            entityDto.Id = Guid.NewGuid();
        }
        
        entityDto.CreatedDate = DateTime.UtcNow;
        
        await Collection.InsertOneAsync(entityDto, cancellationToken: cancellationToken);

        return entityDto;
    }
}