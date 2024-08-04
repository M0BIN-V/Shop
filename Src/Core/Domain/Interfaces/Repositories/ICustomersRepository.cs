using Domain.Entities;
using Domain.Interfaces.Repositories.Common;

namespace Domain.Interfaces.Repositories;

public interface ICustomersRepository : IPersonRoleEntityRepository<Customer>
{

}
