using Microsoft.EntityFrameworkCore;

namespace Api.ServiceInstallers;

public class PersistenceServicesInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer");

        void Action(DbContextOptionsBuilder o) => o.UseSqlServer(connectionString);

        services.AddReadRepositories(Action);
        services.AddWriteRepositories(Action);
    }
}
