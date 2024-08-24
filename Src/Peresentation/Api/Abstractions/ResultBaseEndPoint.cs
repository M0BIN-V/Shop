
namespace Api.Abstractions;

public abstract class ResultBaseEndpoint : IEndpointBuilder
{
    protected readonly IMediator _mediator;

    protected ResultBaseEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public abstract void ConfigureEndpoint(IEndpointRouteBuilder builder);

    protected async Task<IResult> FromResult<TRequest, TResult, TContent>(TRequest request, Func<Result, IResult> successAction)
      where TRequest : IRequest<TResult>
        where TResult : Result<TContent>
    {
        var result = await _mediator.Send(request);

        if (result.IsSuccess)
        {
            return successAction(result);
        }
        else if (result.Errors[0] is ValidationError error)
        {
            var fieldName = (error.Title ?? "").Split('.')[^2];

            var errors = new Dictionary<string, string[]>
            {
                { fieldName, [error.Message] }
            };

            return Results.ValidationProblem(errors);
        }
        else
        {
            return Results.BadRequest(result.Errors);
        }
    }
}
