using Api.Abstractions.Endpoints;
using Application.Commands.Auth;

namespace Api.Endpoints.Auth;

public record SendOtpRequest(string PhoneNumber);
public class OtpEndpoint : ResultBaseEndpoint
{
    public override void ConfigureEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("auth/send-otp", async (SendOtpRequest request, IMediator mediator) =>
        {
            var phoneNumberValueObject = new PhoneNumber { Value = request.PhoneNumber };

            var command = new SendOtpCommand(phoneNumberValueObject);

            var result = await mediator.Send(command);

            return FromResult(result, () => Results.Ok());
        });
    }
}
