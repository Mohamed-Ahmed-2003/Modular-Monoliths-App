using FluentValidation;
using MediatR;
using Shared.CQRS;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Shared.Behaviors;

public class ValidationBehavior <TRequest,TResponse> (IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var ctx = new ValidationContext<TRequest>(request); 
        var validationResult =  await Task
            .WhenAll(validators.Select(v=>v.ValidateAsync(ctx, cancellationToken)));
        
           var failures = validationResult
               .Where(vr=>vr.Errors.Any())
               .SelectMany(v => v.Errors)
               .ToList();

        if (failures.Any())
        {
           throw new FluentValidation.ValidationException(failures);
        }
        
    return  await next();
    }
}