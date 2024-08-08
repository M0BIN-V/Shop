namespace Api;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services

            .AddEndpointsApiExplorer();

        return builder;
    }
}