using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts.Common;

namespace Persistence.DbContexts;

internal class WriteDbContext : DbContextBase
{
    public WriteDbContext() { }
    public WriteDbContext(DbContextOptions<WriteDbContext> dbContextOptions) : base(dbContextOptions) { }
}
