using FluentValidation;
using MediatR;

namespace UtilityBilling.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validator = _validators
            .SingleOrDefault(v => v.CanValidateInstancesOfType(typeof(TRequest)));

        if (validator == null)
        {
            return await next();
        }
        
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (validationResult.IsValid)
        {
            return await next();
        }
        
        throw new ValidationException(validationResult.Errors);
    }
}