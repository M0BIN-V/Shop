using Resulver.AspNetCore.WebApi.ErrorHandling.Abstraction;

namespace Api.ErrorProfiles;

public class CustomerErrorsProfile : ErrorProfile
{
    public CustomerErrorsProfile()
    {
        AddError<CustomerAlreadyExistsError>()
            .WithStatusCode(Status409Conflict);

        AddError<CustomerNotFoundError>()
            .WithStatusCode(Status404NotFound);
    }
}