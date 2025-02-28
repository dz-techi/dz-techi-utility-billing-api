using UtilityBilling.Domain.Common;

namespace UtilityBilling.Infrastructure.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<T> AddAsync(T entityDto, CancellationToken cancellationToken);
    
    Task<T> UpsertAsync(T entityDto, CancellationToken cancellationToken);
    
    Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);
}