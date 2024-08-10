namespace Api.Config;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services

            .AddEndpointsApiExplorer()
            .AddGraphQLServer();

        return builder;
    }
}