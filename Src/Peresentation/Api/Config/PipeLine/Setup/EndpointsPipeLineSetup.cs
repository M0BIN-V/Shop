using Api.Abstractions;

namespace Api.Config.PipeLine.Setup;

public static class EndpointsPipeLineSetup
{
    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        foreach (var endpoint in app.Services.GetRequiredService<IEnumerable<IEndpointBuilder>>())
        {
            endpoint.ConfigureEndpoint(app);
        }

        return app;
    }
}
