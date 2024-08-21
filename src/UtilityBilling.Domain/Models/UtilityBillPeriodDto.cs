using UtilityBilling.Contracts.Common.Enums;
using UtilityBilling.Domain.Common;

namespace UtilityBilling.Domain.Models;

public class UtilityBillPeriodDto : BaseEntity
{
    public Guid UserId { get; set; }

    public DateTime YearMonth { get; set; }

    public List<UtilityBill> UtilityBills { get; set; } = [];
}

public class UtilityBill
{
    public UtilityBillType UtilityBillType { get; set; }

    public decimal Usage { get; set; }

    public decimal Cost { get; set; }

    public MeasurementUnitType MeasurementUnitType { get; set; }
}