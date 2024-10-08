﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Valobtify.EntityFrameworkCore;

namespace Persistence.DbContexts.Common;

public abstract class DbContextBase : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PersonalInformation> PersonalInformation { get; set; }

    protected DbContextBase() { }

    protected DbContextBase(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer();
        }

        optionsBuilder.UseLazyLoadingProxies();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SetupSingleValueObjects();

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}