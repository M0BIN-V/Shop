using Api.Abstractions.Endpoints;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Api.Config.DependencyInjection.Setup;

public static class EndpointsSetup
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services
            .TryAddEnumerable(typeof(EndpointsSetup).Assembly
                .GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface && t
                    .IsAssignableTo(typeof(IEndpointBuilder)))
                .Select(t => ServiceDescriptor.Transient(typeof(IEndpointBuilder), t))
                .ToList());

        return services;
    }
}
