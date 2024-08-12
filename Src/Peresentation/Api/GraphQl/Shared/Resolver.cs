using Api.Mappers;
using HotChocolate.Resolvers;
using MediatR;

namespace Api.GraphQl.Shared;

public class Resolver
{
    public async Task<TResultContent?> Resolve<TRequest, TResultContent>(
        IResolverContext context,
        TRequest request,
        [Service] IMediator mediator)

        where TRequest : IRequest<Resulver.Result<TResultContent>>
    {
        var result = await mediator.Send(request);

        context.ReportErrors(result.Errors.ToGraphQlErrors());

        return result.Content;
    }

    public async Task<string?> Resolve<TRequest>(
        IResolverContext context,
        TRequest request,
        [Service] IMediator mediator)

        where TRequest : IRequest<Resulver.Result>
    {
        var result = await mediator.Send(request);

        context.ReportErrors(result.Errors.ToGraphQlErrors());

        return result.Message;
    }
}
