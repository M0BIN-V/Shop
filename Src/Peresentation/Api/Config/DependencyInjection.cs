using Api.Config.Setup;
using Application;

namespace Api.Config;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services

            .AddApplicationHandlers()

            .AddPersistenceSetup(builder.Configuration)

            .AddEndpointsApiExplorer();

        return builder;
    }
}