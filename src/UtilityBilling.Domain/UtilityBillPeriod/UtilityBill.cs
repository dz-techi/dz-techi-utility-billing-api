using UtilityBilling.Contracts.Common.Enums;
using UtilityBilling.Contracts.Common.UtilityUnitType;

namespace UtilityBilling.Domain.UtilityBillPeriod;

public class UtilityBill
{
    public Guid Id { get; set; }
    
    public UtilityBillType UtilityBillType { get; set; }

    public decimal Usage { get; set; }

    public decimal Cost { get; set; }

    public MeasurementUnitType MeasurementUnitType { get; set; }

    public UtilityBill()
    {
        Id = Guid.NewGuid();
    }
    
    public UtilityBill(UtilityBillType utilityBillType, decimal usage, decimal cost, MeasurementUnitType measurementUnitType)
    {
        Id = Guid.NewGuid();
        UtilityBillType = utilityBillType;
        Usage = usage;
        Cost = cost;
        MeasurementUnitType = measurementUnitType;
    }
    
    public void Update(decimal usage, decimal cost)
    {
        Usage = usage;
        Cost = cost;
    }
}