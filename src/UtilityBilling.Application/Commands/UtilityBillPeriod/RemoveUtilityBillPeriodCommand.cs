using MediatR;

namespace UtilityBilling.Application.Commands.UtilityBillPeriod;

public record RemoveUtilityBillPeriodCommand(Guid UtilityBillPeriodId) : IRequest<bool>;