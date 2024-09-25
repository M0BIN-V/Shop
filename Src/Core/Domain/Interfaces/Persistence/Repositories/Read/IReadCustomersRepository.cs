using Domain.Interfaces.Persistence.Repositories.Read.Abstractions;

namespace Domain.Interfaces.Persistence.Repositories.Read;

public interface IReadCustomersRepository : IReadPersonRoleEntityRepository<Customer>;
