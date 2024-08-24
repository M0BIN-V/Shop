using Application.Commands.Auth;

namespace Api.Endpoints;

public class Auth : ResultBaseEndpoint
{
    public Auth(IMediator mediator) : base(mediator) { }

    public override void ConfigureEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("auth/registerCustomer", async ([FromBody] string phoneNumber) =>
        {
            var command = new RegisterCustomerCommand(new PhoneNumber { Value = phoneNumber });

            return await FromResult<RegisterCustomerCommand, Result<Guid>, Guid>(command, _ => Results.Created());
        })
            .Produces(201);
    }
}
