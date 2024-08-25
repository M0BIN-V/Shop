using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace PersistenceTests.Repositories.Common;

public abstract class RepositoryBase
{
    protected readonly ReadDbContext _readDbContext;
    protected readonly WriteDbContext _writeDbContext;

    public RepositoryBase()
    {
        var dbId = Guid.NewGuid().ToString();

        _readDbContext = new ReadDbContext(BuildOptions<ReadDbContext>(dbId));
        _writeDbContext = new WriteDbContext(BuildOptions<WriteDbContext>(dbId));
    }

    static DbContextOptions<TDbContext> BuildOptions<TDbContext>(string dbId) where TDbContext : DbContext
    {
        var optionBuilder = new DbContextOptionsBuilder<TDbContext>();

        optionBuilder.UseInMemoryDatabase(dbId);

        return optionBuilder.Options;
    }
}
