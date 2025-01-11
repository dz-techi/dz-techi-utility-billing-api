namespace UtilityBilling.Contracts.Results.UtilityBillPeriod;

public class GetUtilityBillPeriodResult
{
    public Guid Id { get; set; }
    
    public DateOnly MonthOfTheYear { get; set; }

    public List<UtilityBillResult> UtilityBills { get; set; } = [];
}