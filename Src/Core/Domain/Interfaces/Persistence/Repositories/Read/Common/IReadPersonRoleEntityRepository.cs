using Domain.Entities.Common;

namespace Domain.Interfaces.Persistence.Repositories.Read.Common;

public interface IReadPersonRoleEntityRepository<TPerson> : IReadRepositoryBase<TPerson>
    where TPerson : PersonRoleEntityBase
{
    public TPerson? Get(PhoneNumber phoneNumber);
}