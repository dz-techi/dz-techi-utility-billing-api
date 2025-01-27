using UtilityBilling.Domain.UtilityBillPeriod;

namespace UtilityBilling.Infrastructure.Repositories.Interfaces;

public interface IUtilityBillPeriodRepository : IBaseRepository<UtilityBillPeriodDto>
{
    Task<UtilityBillPeriodDto?> GetByUserIdAndMonthOfTheYearAsync(Guid userId, DateOnly monthOfTheYear, CancellationToken cancellationToken);
    
    Task<IList<UtilityBillPeriodDto>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}