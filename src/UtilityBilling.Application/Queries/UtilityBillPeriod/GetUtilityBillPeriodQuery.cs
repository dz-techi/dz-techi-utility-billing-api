using MediatR;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;

namespace UtilityBilling.Application.Queries.UtilityBillPeriod;

public record GetUtilityBillPeriodQuery(Guid UtilityBillPeriodId) : IRequest<GetUtilityBillPeriodResult?>;
