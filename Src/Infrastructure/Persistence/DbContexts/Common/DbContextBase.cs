using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.DbContexts.Common;

public abstract class DbContextBase : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PersonalInformation> PersonalInformation { get; set; }

    protected DbContextBase() { }

    public DbContextBase(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
