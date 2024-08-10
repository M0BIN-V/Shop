using Domain.Interfaces.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace PersistenceTests.Repositories.Abstractions;

internal class RepositoryProvider
{
    public string DataBaseId { get; } = Guid.NewGuid().ToString();

    public TRepository Get<TRepository>()
        where TRepository : IRepository
    {
        void SetupOptions(DbContextOptionsBuilder options) => options.UseInMemoryDatabase(DataBaseId);

        var services = new ServiceCollection()
            .AddReadRepositories(SetupOptions)
            .AddWriteRepositories(SetupOptions)
            .BuildServiceProvider();

        return services.GetRequiredService<TRepository>();
    }
}
