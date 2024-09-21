using Application.Errors;
using Resulver.AspNetCore.WebApi.ErrorHandling.Abstraction;

namespace Api.ErrorProfiles;

public class RateLimitErrorProfile : ErrorProfile
{
    public RateLimitErrorProfile()
    {
        AddError<RateLimitError>()
            .WithStatusCode(Status429TooManyRequests);
    }
}
public class OtpIsNotValidErrorProfile : ErrorProfile
{
    public OtpIsNotValidErrorProfile()
    {
        AddError<OtpIsNotValidError>().WithStatusCode(Status400BadRequest);
    }
}
