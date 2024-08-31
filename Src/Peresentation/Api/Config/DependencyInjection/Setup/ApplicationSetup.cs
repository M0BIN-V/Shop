using Persistence;
using Application;

namespace Api.Config.DependencyInjection.Setup;

public static class ApplicationSetup
{
    public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
    {
        services
            .AddOtpService()
            .AddSmsService()
            .AddApplicationHandlers();

        return services;
    }
}
