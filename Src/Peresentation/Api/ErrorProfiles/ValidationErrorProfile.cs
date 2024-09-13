using Microsoft.AspNetCore.Mvc;
using Resulver.AspNetCore.WebApi.ErrorHandling.Abstraction;

namespace Api.ErrorProfiles;

public class ValidationErrorProfile : ErrorProfile
{
    public ValidationErrorProfile()
    {
        AddError<ValidationError>()
           .HandleWith(error =>
           {
               var splitErrorTitle = error.Title!.Split('.');

               var fieldName = splitErrorTitle[^1] is "Value" ?
                   splitErrorTitle[^2] : splitErrorTitle[^1];

               var errors = new Dictionary<string, string[]>
               {
                    { fieldName, [error.Message] }
               };

               ValidationProblemDetails validationProblem = new()
               {
                   Errors = errors
               };

               return new BadRequestObjectResult(validationProblem);
           });
    }
}