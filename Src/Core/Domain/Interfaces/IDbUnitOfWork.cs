using Domain.Interfaces.Repositories;

namespace Domain.Interfaces;

public interface IDbUnitOfWork
{
    public ICustomersRepository CustomersRepository { get; set; }
}
