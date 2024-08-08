namespace Api;

public static class PipeLine
{
    public static WebApplication ConfigurePipeLine(this WebApplication app)
    {
        app.UseHttpsRedirection();

        return app;
    }
}
