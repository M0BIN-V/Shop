using Resulver.AspNetCore.WebApi;

namespace Api.Config.DependencyInjection.Setup;

public static class ErrorHandlingSetup
{
    public static IServiceCollection AddErrorHandlingSetup(this IServiceCollection services)
    {
        services
            .AddErrorProfilesFromAssembly(typeof(ErrorHandlingSetup).Assembly)
            .AddErrorResponseGenerator();

        return services;
    }
}
