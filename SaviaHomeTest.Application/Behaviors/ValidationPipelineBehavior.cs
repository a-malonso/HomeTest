using FluentValidation;
using MediatR;
using SaviaHomeTest.Domain.Exceptions;

namespace SaviaHomeTest.Application.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> 
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _Validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _Validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_Validators.Any()) return await next();

        IEnumerable<string> errors = _Validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure != null)
            .Select(failure => failure.ErrorMessage)
            .Distinct()
            .ToList();

        if (errors.Any())
        {
            throw new InputValidationException(errors);
        }

        return await next();
    }
}
