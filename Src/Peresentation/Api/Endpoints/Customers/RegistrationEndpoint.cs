using Api.Abstractions.Endpoints;
using Application.Commands.Auth;

namespace Api.Endpoints.Customers;

public record RegisterRequest(string PhoneNumber);

public class RegistrationEndpoint : ResultBaseEndpoint
{
    public override void ConfigureEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("customers/register", async (IMediator mediator, RegisterRequest request) =>
        {
            var command = new RegisterCustomerCommand(new PhoneNumber { Value = request.PhoneNumber });

            var result = await mediator.Send(command);

            return FromResult(result, () => Results.Created("", result.Content));
        })
            .Produces<Guid>(Status201Created);
    }
}
