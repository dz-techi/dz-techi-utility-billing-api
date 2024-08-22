using UtilityBilling.Domain.Models;

namespace UtilityBilling.Infrastructure.Repositories.Interfaces;

public interface IUtilityBillPeriodRepository : IBaseRepository<UtilityBillPeriodDto>
{
    Task<IList<UtilityBillPeriodDto>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}