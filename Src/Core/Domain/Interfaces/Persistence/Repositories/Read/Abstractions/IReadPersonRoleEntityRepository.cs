using Domain.Entities.Abstractions;

namespace Domain.Interfaces.Persistence.Repositories.Read.Abstractions;

public interface IReadPersonRoleEntityRepository<TPerson> : IReadRepositoryBase<TPerson>
    where TPerson : PersonRoleEntityBase
{
    public TPerson? Get(PhoneNumber phoneNumber);
    public bool Exists(PhoneNumber phoneNumber);
}