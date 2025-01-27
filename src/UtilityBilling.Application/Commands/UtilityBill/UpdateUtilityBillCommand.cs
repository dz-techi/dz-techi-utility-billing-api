using MediatR;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;

namespace UtilityBilling.Application.Commands.UtilityBill;

public record UpdateUtilityBillCommand(Guid UtilityBillPeriodId, Guid UtilityBillId, decimal Usage, decimal Cost) : IRequest<GetUtilityBillPeriodResult?>;