using Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config
            .RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
            .AddOpenBehavior(typeof(ValidationPipLineBehavior<,>));
        });

        return services;
    }
}
