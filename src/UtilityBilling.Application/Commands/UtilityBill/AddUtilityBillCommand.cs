using MediatR;
using UtilityBilling.Contracts.Requests.UtilityBillPeriod;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;

namespace UtilityBilling.Application.Commands.UtilityBill;

public record AddUtilityBillCommand(Guid UtilityBillPeriodId, AddUtilityBillRequest UtilityBill) : IRequest<GetUtilityBillPeriodResult?>;