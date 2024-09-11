using Api.Services.ResultErrorHandler.Abstraction;

namespace Api.ErrorProfiles;

public class ValidationErrorProfile : ErrorProfile
{
    public override void ConfigureErrors()
    {
        AddError<ValidationError>()
            .HandleWith(error =>
            {
                var splitErrorTitle = error.Title!.Split('.');

                var fieldName = splitErrorTitle[^1] is "Value" ?
                    splitErrorTitle[^2] : splitErrorTitle[^1];

                var errors = new Dictionary<string, string[]>
                {
                    { fieldName.ToLower(), [error.Message] }
                };

                return Results.ValidationProblem(errors);
            })
            .WithStatusCode(Status400BadRequest);
    }
}
