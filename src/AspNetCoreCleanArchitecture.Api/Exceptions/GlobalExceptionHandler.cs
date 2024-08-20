using System.Net;
using AspNetCoreCleanArchitecture.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCleanArchitecture.Api.Exceptions;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var result = new ProblemDetails();

        switch (exception)
        {
            case EntityNotFoundException entityNotFoundException:
                result = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Type = entityNotFoundException.GetType().Name,
                    Title = "An unexpected error occurred",
                    Detail = entityNotFoundException.Message,
                    Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                };
                // _logger.LogError(argumentNullException, $"Exception occured : {argumentNullException.Message}");
                break;
        }
        
        await httpContext.Response.WriteAsJsonAsync(result, cancellationToken: cancellationToken);
        
        return true;
    }
}