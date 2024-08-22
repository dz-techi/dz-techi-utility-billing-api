namespace UtilityBilling.Contracts.Results.UtilityBillPeriod;

public class GetUtilityBillPeriodResult
{
    public Guid Id { get; set; }
    
    public DateTime YearMonth { get; set; }

    public List<UtilityBillResult> UtilityBills { get; set; } = [];
}