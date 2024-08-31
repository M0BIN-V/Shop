using Api.Config.DependencyInjection.Setup;

namespace Api.Config.DependencyInjection;

public static class ConfigureDependenciesExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services

            .AddApplicationSetup()

            .AddPersistenceSetup(builder.Configuration)

            .AddSwaggerGen()

            .AddEndpoints()

            .AddEndpointsApiExplorer();

        return builder;
    }
}