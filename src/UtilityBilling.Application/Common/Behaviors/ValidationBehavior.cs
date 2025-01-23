using FluentValidation;
using MediatR;

namespace UtilityBilling.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest>? _validator = validator;
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator == null)
        {
            return await next();
        }
        
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        
        if (validationResult.IsValid)
        {
            return await next();
        }
        
        throw new ValidationException(validationResult.Errors);
    }
}