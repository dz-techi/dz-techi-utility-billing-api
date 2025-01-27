using UtilityBilling.Contracts.Common.Enums;
using UtilityBilling.Contracts.Common.UtilityUnitType;
using UtilityBilling.Domain.Common;
using UtilityBilling.Domain.Exceptions;

namespace UtilityBilling.Domain.UtilityBillPeriod;

public class UtilityBillPeriodDto : BaseEntity
{
    public Guid UserId { get; set; }

    public DateOnly MonthOfTheYear { get; set; }

    public List<UtilityBill> UtilityBills { get; set; } = [];

    public UtilityBillPeriodDto() {}
    
    public UtilityBillPeriodDto(Guid userId, DateOnly monthOfTheYear)
    {
        UserId = userId;
        MonthOfTheYear = monthOfTheYear;
    }

    public void AddUtilityBill(UtilityBillType utilityBillType, decimal usage, decimal cost, MeasurementUnitType measurementUnitType)
    {
        var utilityBillAlreadyExists = UtilityBills.Any(ub => ub.UtilityBillType == utilityBillType);
        
        if (utilityBillAlreadyExists)
        {
            throw new EntityAlreadyExistsException($"Utility bill of type {utilityBillType} already exists for this utility bill period.");
        }
        
        var utilityBill = new UtilityBill(utilityBillType, usage, cost, measurementUnitType);
        
        UtilityBills.Add(utilityBill);
    }
    
    public void RemoveUtilityBill(Guid utilityBillId)
    {
        var utilityBill = UtilityBills.SingleOrDefault(ub => ub.Id == utilityBillId);
        
        if (utilityBill == null)
        {
            throw new EntityNotFoundException($"Utility bill with id {utilityBillId} not found.");
        }
        
        UtilityBills.Remove(utilityBill);
    }
    
    public UtilityBill? FindBillById(Guid utilityBillId)
    {
        return UtilityBills.SingleOrDefault(ub => ub.Id == utilityBillId);
    }
}