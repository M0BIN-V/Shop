using Api.Config.PipeLine.Setup;

namespace Api.Config.PipeLine;

public static class ConfigurePipeLineExtensions
{
    public static WebApplication ConfigurePipeLine(this WebApplication app)
    {
        app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        return app;
    }
}
