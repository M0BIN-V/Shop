using Api.Abstractions.Endpoints;
using Application.Commands.Auth;

namespace Api.Endpoints.Auth;

public class OtpEndpoint : ResultBaseEndpoint
{
    public override void ConfigureEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("auth/send-otp", async ([FromBody] string phoneNumber, IMediator mediator) =>
        {
            var phoneNumberValueObject = new PhoneNumber { Value = phoneNumber };

            var command = new SendOtpRequest(phoneNumberValueObject);

            var result = await mediator.Send(command);

            return FromResult(result, () => Results.Ok());
        });
    }
}
