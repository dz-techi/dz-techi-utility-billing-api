using MediatR;
using UtilityBilling.Application.Commands.UtilityBillPeriod;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;

namespace UtilityBilling.Application.Handlers.UtilityBillPeriod;

public class AddUtilityBillPeriodHandler : IRequestHandler<AddUtilityBillPeriodCommand, GetUtilityBillPeriodResult?>
{
    public Task<GetUtilityBillPeriodResult?> Handle(AddUtilityBillPeriodCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}