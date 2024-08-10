namespace Api.Config;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services

            .AddApplicationHandlers()

            .AddPersistence(builder.Configuration)

            .AddEndpointsApiExplorer()
            .AddGraphQLServer();

        return builder;
    }

    static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("SqlServer");

        void Action(DbContextOptionsBuilder o) => o.UseSqlServer(connectionString);

        services.AddReadRepositories(Action);
        services.AddWriteRepositories(Action);

        return services;
    }
}