using Application.Commands.Auth;

namespace Api.Endpoints;

public class Auth : ResultBaseEndpoint
{
    public override void ConfigureEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("auth/registerCustomer", async (IMediator mediator, [FromBody] string phoneNumber) =>
        {
            var command = new RegisterCustomerCommand(new PhoneNumber { Value = phoneNumber });

            var result = await mediator.Send(command);

            return FromResult(result, _ => Results.Created());
        })
            .Produces(Status201Created);
    }
}
