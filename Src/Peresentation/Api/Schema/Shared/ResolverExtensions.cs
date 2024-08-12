using HotChocolate.Resolvers;
using MediatR;
using Resulver;

namespace Api.Schema.Shared;

public static class ResolverExtensions
{
    public static IObjectFieldDescriptor ResolveRequest<TRequest, TResultContent>(
        this IObjectFieldDescriptor descriptor)
        where TRequest : IRequest<Resulver.Result<TResultContent>>
    {
        descriptor.WithRequestArgument<TRequest>();

        descriptor.ResolveWith<Resolver>(r => r
            .ResolveWithMediator<TRequest, TResultContent>(default!, default!, default!));

        return descriptor;
    }

    public static IObjectFieldDescriptor ResolveRequest<TRequest>(this IObjectFieldDescriptor descriptor)
        where TRequest : IRequest<Result>
    {
        descriptor.WithRequestArgument<TRequest>();

        descriptor.ResolveWith<Resolver>(r => r
            .ResolveWithMediator<TRequest>(default!, default!, default!));

        return descriptor;
    }

    public static IObjectFieldDescriptor WithRequestArgument<TRequest>(this IObjectFieldDescriptor descriptor)
    {
        descriptor.Argument("request", a => a.Type<RequestInput<TRequest>>());

        return descriptor;
    }

    public static void ReportErrors(this IResolverContext context, List<Error> errors)
    {
        foreach (var error in errors)
        {
            context.ReportError(error);
        }
    }
}
