using Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using Validity.DataAnnotation;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationHandlers(this IServiceCollection services)
    {
        services.AddObjectValidator();

        services.AddMediatR(config =>
        {
            config
            .RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
            .AddOpenBehavior(typeof(ValidationPipLineBehavior<,>));
        });

        return services;
    }
}
