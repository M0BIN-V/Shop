using Domain.Entities;
using Domain.Interfaces.Persistence.Repositories.Write.Common;

namespace Domain.Interfaces.Persistence.Repositories.Write;

public interface IWriteCustomersRepository : IWriteEntityRepositoryBase<Customer>
{
}
