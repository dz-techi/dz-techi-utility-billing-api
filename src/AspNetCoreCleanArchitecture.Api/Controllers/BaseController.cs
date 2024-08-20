using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCleanArchitecture.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : Controller
{
    protected readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}