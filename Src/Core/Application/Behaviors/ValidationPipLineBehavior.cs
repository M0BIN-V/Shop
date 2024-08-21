using Validity.DataAnnotation;

namespace Application.Behaviors;

internal class ValidationPipLineBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
    where TRequest : IRequest<TResult>
    where TResult : Result
{
    readonly IObjectValidator _validator;

    public ValidationPipLineBehavior(IObjectValidator validator)
    {
        _validator = validator;
    }

    public Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        var errors = _validator
            .Validate(request, "Request")
            .Select(error => new ValidationError(error.Message ?? "", error.Name))
            .ToArray();

        if (errors.Length > 0)
        {
            return Task.FromResult(ResultGenerator<TResult>.MakeResult(errors));
        }

        return next();
    }
}