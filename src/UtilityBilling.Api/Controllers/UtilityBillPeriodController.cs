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
    private readonly ILogger<UtilityBillPeriodController> _logger;
    
    public UtilityBillPeriodController(IMediator mediator, ILogger<UtilityBillPeriodController> logger) : base(mediator)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetUtilityBillPeriodResult>>> GetUtilityBillPeriodsAsync(CancellationToken cancellationToken)
    {
        var getUtilityBillPeriodsQuery = new GetUtilityBillPeriodsQuery();
        
        _logger.LogInformation("Getting utility bill periods.");

        var result = await _mediator.Send(getUtilityBillPeriodsQuery, cancellationToken);

        if (result.Count == 0)
        {
            return NoContent();
        }

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<GetUtilityBillPeriodResult>> AddUtilityBillPeriodAsync([FromBody] AddUtilityBillPeriodRequest request, CancellationToken cancellationToken)
    {
        var addUtilityBillPeriodCommand = new AddUtilityBillPeriodCommand(request.MonthOfTheYear);

        var result = await _mediator.Send(addUtilityBillPeriodCommand, cancellationToken);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUtilityBillPeriodResult>> GetUtilityBillPeriodByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var getUtilityBillPeriodByIdQuery = new GetUtilityBillPeriodQuery(id);
        
        var result = await _mediator.Send(getUtilityBillPeriodByIdQuery, cancellationToken);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveUtilityBillPeriodByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var removeUtilityBillPeriodCommand = new RemoveUtilityBillPeriodCommand(id);
        
        var result = await _mediator.Send(removeUtilityBillPeriodCommand, cancellationToken);

        if (!result)
        {
            return BadRequest();
        }

        return NoContent();
    }
    
    // TODO: Add utility bill to bill period
    
    // TODO: Edit utility bill in bill period
    
    // TODO: Delete utility bill from bill period
}