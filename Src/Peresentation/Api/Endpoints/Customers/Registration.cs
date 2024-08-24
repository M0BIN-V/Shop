using Application.Commands.Auth;

namespace Api.Endpoints.Customers;

public class Registration : ResultBaseEndpoint
{
    public override void ConfigureEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("customers/register", async (IMediator mediator, [FromBody] string phoneNumber) =>
        {
            var command = new RegisterCustomerCommand(new PhoneNumber { Value = phoneNumber });

            var result = await mediator.Send(command);

            return FromResult(result, () => Results.Created("", result.Content));
        })
            .Produces<Guid>(Status201Created);
    }
}
