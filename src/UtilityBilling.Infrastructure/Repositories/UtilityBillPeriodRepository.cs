using UtilityBilling.Domain.Models;
using UtilityBilling.Infrastructure.Constants;
using UtilityBilling.Infrastructure.Database;
using UtilityBilling.Infrastructure.Repositories.Interfaces;

namespace UtilityBilling.Infrastructure.Repositories;

public class UtilityBillPeriodRepository : BaseRepository<UtilityBillPeriodDto>, IUtilityBillPeriodRepository
{
    protected override string CollectionName => Collections.UtilityBillPeriods;
    
    public UtilityBillPeriodRepository(IAppDbContext appDbContext) : base(appDbContext)
    {
    }
}