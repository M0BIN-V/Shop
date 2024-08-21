using Api.Config.Services.Setup;
using Application;

namespace Api.Config.Services;

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