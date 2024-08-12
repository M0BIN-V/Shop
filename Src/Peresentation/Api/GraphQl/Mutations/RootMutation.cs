using Api.GraphQl.Shared;
using Application.Commands.Auth;

namespace Api.GraphQl.Mutations;

public class RootMutation { }

public class RootMutationType : ObjectType<RootMutation>
{
    protected override void Configure(IObjectTypeDescriptor<RootMutation> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field("registerCustomer")
            .ResolveRequest<RegisterCustomerCommand>();

        base.Configure(descriptor);
    }
}
