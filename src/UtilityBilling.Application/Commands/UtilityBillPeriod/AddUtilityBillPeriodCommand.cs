using MediatR;
using UtilityBilling.Contracts.Requests.UtilityBillPeriod;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;

namespace UtilityBilling.Application.Commands.UtilityBillPeriod;

public record AddUtilityBillPeriodCommand(DateOnly MonthOfTheYear) : IRequest<GetUtilityBillPeriodResult?>;