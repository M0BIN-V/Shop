using Api.Abstractions;
using Application.Commands.Auth;
using MediatR;

namespace Api.Endpoints;

public class Auth : IEndpointBuilder
{
    public void ConfigureEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("auth/registerCustomer", async (IMediator mediator, RegisterCustomerCommand request) =>
        {
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });
    }
}
