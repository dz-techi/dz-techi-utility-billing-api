using AspNetCoreCleanArchitecture.Domain.Common;

namespace AspNetCoreCleanArchitecture.Infrastructure.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<T?> AddAsync(T entityDto, CancellationToken cancellationToken);
}