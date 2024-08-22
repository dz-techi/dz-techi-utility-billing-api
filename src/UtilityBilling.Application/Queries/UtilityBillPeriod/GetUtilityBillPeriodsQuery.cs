using MediatR;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;

namespace UtilityBilling.Application.Queries.UtilityBillPeriod;

public class GetUtilityBillPeriodsQuery : IRequest<List<GetUtilityBillPeriodResult>>
{
    
}