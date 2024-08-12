using Domain.Entities;
using Domain.Interfaces.Persistence.Repositories.Read;
using Persistence.DbContexts;
using Persistence.Repositories.Read.Abstractions;

namespace Persistence.Repositories.Read;

public class ReadCustomersRepository : ReadPersonRoleRepository<Customer>, IReadCustomersRepository
{
    public ReadCustomersRepository(ReadDbContext context) : base(context) { }
}
