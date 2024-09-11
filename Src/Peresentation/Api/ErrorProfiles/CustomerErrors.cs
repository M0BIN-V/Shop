using Api.Services.ResultErrorHandler.Abstraction;

namespace Api.ErrorProfiles;

public class CustomerErrors : ErrorProfile
{
    public override void ConfigureErrors()
    {
        AddError<CustomerAlreadyExistsError>()
            .WithStatusCode(Status409Conflict);

        AddError<CustomerNotFoundError>()
            .WithStatusCode(Status404NotFound);
    }
}