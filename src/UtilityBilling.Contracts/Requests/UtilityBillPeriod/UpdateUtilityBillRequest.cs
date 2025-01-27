namespace UtilityBilling.Contracts.Requests.UtilityBillPeriod;

public class UpdateUtilityBillRequest
{
    public decimal Usage { get; set; }
    
    public decimal Cost { get; set; }
}