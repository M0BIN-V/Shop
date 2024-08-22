using Api.Config.DependencyInjection.Setup;
using Application;

namespace Api.Config.DependencyInjection;

public static class ConfigureDependenciesExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services

            .AddApplicationHandlers()

            .AddSwaggerGen()

            .AddPersistenceSetup(builder.Configuration)

            .AddEndpoints()

            .AddEndpointsApiExplorer();

        return builder;
    }
}