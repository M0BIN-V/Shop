using Domain.Entities.Abstractions;
using Domain.Interfaces.Persistence.Repositories.Read.Abstractions;
using Persistence.DbContexts;

namespace Persistence.Repositories.Read.Abstractions;

public abstract class ReadPersonRoleRepository<TPerson> : ReadRepositoryBase<TPerson>, IReadPersonRoleEntityRepository<TPerson>
    where TPerson : PersonRoleEntityBase
{
    protected ReadPersonRoleRepository(ReadDbContext context) : base(context) { }

    public bool Exists(PhoneNumber phoneNumber)
    {
        return _set.Any(x => x.PersonalInformation.PhoneNumber.Equals(phoneNumber));
    }

    public TPerson? Get(PhoneNumber phoneNumber)
    {
        return _set.SingleOrDefault(x => x.PersonalInformation.PhoneNumber.Equals(phoneNumber));
    }
}
