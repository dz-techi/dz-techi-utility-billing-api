using UtilityBilling.Contracts.Common.Enums;
using UtilityBilling.Contracts.Common.UtilityUnitType;

namespace UtilityBilling.Contracts.Requests.UtilityBillPeriod;

public class AddUtilityBillRequest
{
    public UtilityBillType UtilityBillType { get; set; }

    public decimal Usage { get; set; }
    
    public decimal Cost { get; set; }

    // Could be resolved by utility bill type
    public MeasurementUnitType MeasurementUnitType { get; set; }
}