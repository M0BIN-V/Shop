using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts.Common;
using Persistence.Interceptors;

namespace Persistence.DbContexts;

public class WriteDbContext : DbContextBase
{
    public WriteDbContext() { }
    public WriteDbContext(DbContextOptions<WriteDbContext> dbContextOptions) : base(dbContextOptions) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AddEntityInterceptor());

        base.OnConfiguring(optionsBuilder);
    }
}
