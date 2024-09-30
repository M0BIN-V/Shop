using Resulver.AspNetCore.WebApi.ErrorHandling.Abstraction;

namespace Api.ErrorProfiles;

public class ProductErrorsProfile : ErrorProfile
{
    public ProductErrorsProfile()
    {
        AddError<ProductAlreadyExistsError>().WithStatusCode(Status409Conflict);
    }
}
