using Application.Commands.Auth;
using MediatR;

namespace Api.GraphQl.Mutations;

public class RootMutation
{
    public async Task<Guid> RegisterCustomer(
        string phoneNumber,
        [Service] IMediator mediator)
    {
        var request = new RegisterCustomerCommand(PhoneNumber: new PhoneNumber { Value = phoneNumber });

        var result = await mediator.Send(request);

        return result.Content;
    }
}
