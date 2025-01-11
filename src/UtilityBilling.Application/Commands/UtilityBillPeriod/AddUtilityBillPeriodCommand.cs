using MediatR;
using UtilityBilling.Contracts.Requests.UtilityBillPeriod;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;

namespace UtilityBilling.Application.Commands.UtilityBillPeriod;

public class AddUtilityBillPeriodCommand : IRequest<GetUtilityBillPeriodResult?>
{
    public AddUtilityBillPeriodRequest UtilityBillPeriodRequest { get; }

    public AddUtilityBillPeriodCommand(AddUtilityBillPeriodRequest utilityBillPeriodRequest)
    {
        UtilityBillPeriodRequest = utilityBillPeriodRequest;
    }
}