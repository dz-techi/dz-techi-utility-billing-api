using AspNetCoreCleanArchitecture.Application.Commands.Product;
using AspNetCoreCleanArchitecture.Application.Queries.Product;
using AspNetCoreCleanArchitecture.Contracts.Requests.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCleanArchitecture.Api.Controllers;

public class ProductController : BaseController
{
    private readonly ILogger<ProductController> _logger;
    
    public ProductController(ILogger<ProductController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var getProductQuery = new GetProductQuery(id);

        var result = await _mediator.Send(getProductQuery, cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddProductRequest request, CancellationToken cancellationToken)
    {
        var addProductCommand = new AddProductCommand(request);

        var result = await _mediator.Send(addProductCommand, cancellationToken);

        if (result == null)
        {
            return BadRequest();
        }
        
        return Ok(result);
    }
}