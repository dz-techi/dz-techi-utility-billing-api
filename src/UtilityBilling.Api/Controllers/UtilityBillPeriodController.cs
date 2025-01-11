using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UtilityBilling.Application.Commands.UtilityBillPeriod;
using UtilityBilling.Application.Queries.UtilityBillPeriod;
using UtilityBilling.Contracts.Requests.UtilityBillPeriod;
using UtilityBilling.Contracts.Results.UtilityBillPeriod;

namespace UtilityBilling.Api.Controllers;

// [Authorize]
[Route("api/utility-bill-periods")]
public class UtilityBillPeriodController : BaseController
{
    public UtilityBillPeriodController(IMediator mediator) : base(mediator)
    {
        
    }
    
    [HttpGet]
    public async Task<ActionResult<List<UtilityBillResult>>> GetUtilityBillPeriodsAsync(CancellationToken cancellationToken)
    {
        var getUtilityBillPeriodsQuery = new GetUtilityBillPeriodsQuery();

        var result = await _mediator.Send(getUtilityBillPeriodsQuery, cancellationToken);

        if (result.Count == 0)
        {
            return NoContent();
        }

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<UtilityBillResult>> AddUtilityBillPeriodAsync([FromBody] AddUtilityBillPeriodRequest request, CancellationToken cancellationToken)
    {
        var addUtilityBillPeriodCommand = new AddUtilityBillPeriodCommand(request);

        var result = await _mediator.Send(addUtilityBillPeriodCommand, cancellationToken);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    // TODO: Get bill period by id
}