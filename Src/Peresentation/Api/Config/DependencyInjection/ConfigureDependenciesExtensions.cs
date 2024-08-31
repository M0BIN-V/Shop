using Api.Config.DependencyInjection.Setup;
using Application;
using Persistence;

namespace Api.Config.DependencyInjection;

public static class ConfigureDependenciesExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services

            .AddSmsService()

            .AddApplicationHandlers()

            .AddSwaggerGen()

            .AddPersistenceSetup(builder.Configuration)

            .AddEndpoints()

            .AddEndpointsApiExplorer();

        return builder;
    }
}