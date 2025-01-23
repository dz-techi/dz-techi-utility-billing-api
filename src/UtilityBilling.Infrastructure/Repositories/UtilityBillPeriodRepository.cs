using MongoDB.Driver;
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

    public async Task<UtilityBillPeriodDto?> GetByUserIdAndMonthOfTheYearAsync(
        Guid userId, 
        DateOnly monthOfTheYear,
        CancellationToken cancellationToken)
    {
        var startOfMonth = new DateOnly(monthOfTheYear.Year, monthOfTheYear.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1);

        var filter = Builders<UtilityBillPeriodDto>.Filter.And(
            Builders<UtilityBillPeriodDto>.Filter.Eq(u => u.UserId, userId),
            Builders<UtilityBillPeriodDto>.Filter.Gte(u => u.MonthOfTheYear, startOfMonth),
            Builders<UtilityBillPeriodDto>.Filter.Lt(u => u.MonthOfTheYear, endOfMonth));
        
        return await Collection.Find(filter).SingleOrDefaultAsync(cancellationToken);
    }
    
    public async Task<IList<UtilityBillPeriodDto>> GetAllByUserIdAsync(
        Guid userId, 
        CancellationToken cancellationToken)
    {
        var filter = Builders<UtilityBillPeriodDto>.Filter.Eq(u => u.UserId, userId);

        var sortDefinition = Builders<UtilityBillPeriodDto>.Sort.Ascending(u => u.MonthOfTheYear);

        return await Collection.Find(filter).Sort(sortDefinition).ToListAsync(cancellationToken);
    }
}