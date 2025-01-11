using UtilityBilling.Contracts.Common.Enums;
using UtilityBilling.Contracts.Common.UtilityUnitType;

namespace UtilityBilling.Contracts.Results.UtilityBillPeriod;

public class UtilityBillResult
{
    public UtilityBillType UtilityBillType { get; set; }

    public decimal Usage { get; set; }
    
    public decimal Cost { get; set; }

    public MeasurementUnitType MeasurementUnitType { get; set; }
}