using Domain.Entities;
using Domain.Interfaces.Persistence.Repositories.Read.Common;

namespace Domain.Interfaces.Persistence.Repositories.Read;

public interface IReadCustomersRepository : IReadPersonRoleEntityRepository<Customer>
{

}
