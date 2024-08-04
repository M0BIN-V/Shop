using Domain.Entities.Common;

namespace Domain.Interfaces.Repositories.Common;

public interface IPersonRoleEntityRepository<TPerson> : IRepositoryBase<TPerson>
    where TPerson : PersonRoleEntityBase
{
    public TPerson? Find(PhoneNumber phoneNumber);
    public TPerson? Find(Email email);
}