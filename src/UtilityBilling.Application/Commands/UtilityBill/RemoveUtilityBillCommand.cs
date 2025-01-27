using MediatR;

namespace UtilityBilling.Application.Commands.UtilityBill;

public record RemoveUtilityBillCommand(Guid UtilityBillPeriodId, Guid UtilityBillId) : IRequest<bool>;