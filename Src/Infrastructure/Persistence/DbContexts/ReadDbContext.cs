using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts.Common;

namespace Persistence.DbContexts;

public class ReadDbContext : DbContextBase
{
    public ReadDbContext() { }

    public ReadDbContext(DbContextOptions<ReadDbContext> dbContextOptions) : base(dbContextOptions) { }
}