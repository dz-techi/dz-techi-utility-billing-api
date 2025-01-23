using FluentValidation;

namespace UtilityBilling.Application.Commands.UtilityBillPeriod;

public class AddUtilityBillPeriodCommandValidator : AbstractValidator<AddUtilityBillPeriodCommand>
{
    public AddUtilityBillPeriodCommandValidator()
    {
        var tomorrow = DateOnly.FromDateTime(DateTime.UtcNow).AddDays(1);
        
        RuleFor(u => u.MonthOfTheYear).LessThan(tomorrow);
    }
}