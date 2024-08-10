using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DbContexts;
using Persistence.Repositories.Read;
using Persistence.Repositories.Write;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddReadRepositories
        (this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null)
    {
        services.AddDbContext<ReadDbContext>(optionsAction);

        services.AddTransient<IReadCustomersRepository, ReadCustomersRepository>();

        return services;
    }

    public static IServiceCollection AddWriteRepositories
        (this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null)
    {
        services.AddDbContext<WriteDbContext>(optionsAction);

        services.AddTransient<IWriteCustomersRepository, WriteCustomerRepository>();

        return services;
    }
}
