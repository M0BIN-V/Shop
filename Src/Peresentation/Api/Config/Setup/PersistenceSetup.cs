using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Api.Config.Setup;

public static class PersistenceSetup
{
    public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("SqlServer");

        void Action(DbContextOptionsBuilder o) => o.UseSqlServer(connectionString);

        services.AddReadRepositories(Action);
        services.AddWriteRepositories(Action);

        return services;
    }
}
