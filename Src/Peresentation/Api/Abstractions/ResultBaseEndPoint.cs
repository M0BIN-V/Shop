
namespace Api.Abstractions;

public abstract class ResultBaseEndpoint : IEndpointBuilder
{
    public abstract void ConfigureEndpoint(IEndpointRouteBuilder builder);

    protected IResult FromResult(Result result, Func<IResult> successAction)
    {
        if (result.IsSuccess)
        {
            return successAction();
        }
        else
        {
            return HandleErrors(result.Errors);
        }
    }

    protected IResult HandleErrors(List<ResultError> resultErrors)
    {
        if (resultErrors[0] is ValidationError error)
        {
            var splitErrorTitle = error.Title!.Split('.');

            var fieldName = splitErrorTitle[^1] is "Value" ?
                splitErrorTitle[^2] : splitErrorTitle[^1];

            var errors = new Dictionary<string, string[]>
            {
                { fieldName.ToLower(), [error.Message] }
            };

            return Results.ValidationProblem(errors);
        }
        else
        {
            return Results.BadRequest(resultErrors);
        }
    }
}
