using MediatR;
using Microsoft.AspNetCore.Mvc;
using UtilityBilling.Application.Queries.UtilityBillPeriod;

namespace UtilityBilling.Api.Controllers;

public class UtilityBillPeriodController : BaseController
{
    public UtilityBillPeriodController(IMediator mediator) : base(mediator)
    {
        
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUtilityBillPeriods(CancellationToken cancellationToken)
    {
        var getUtilityBillPeriodsQuery = new GetUtilityBillPeriodsQuery();

        var result = await _mediator.Send(getUtilityBillPeriodsQuery, cancellationToken);

        if (result.Count == 0)
        {
            return NoContent();
        }

        return Ok(result);
    }
    
    // TODO: Create utility bill period
    // TODO: Get bill period by id
}