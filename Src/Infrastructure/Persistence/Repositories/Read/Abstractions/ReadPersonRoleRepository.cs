using Domain.Interfaces.Persistence.Repositories.Read.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Persistence.Repositories.Read.Abstractions;

public abstract class ReadPersonRoleRepository<TPerson> : ReadRepositoryBase<TPerson>, IReadPersonRoleEntityRepository<TPerson>
    where TPerson : PersonRoleEntityBase
{
    protected ReadPersonRoleRepository(ReadDbContext context) : base(context) { }

    public async Task<bool> ExistsAsync(PhoneNumber phoneNumber)
    {
        return await _set.AnyAsync(x => x.PersonalInformation.PhoneNumber.Equals(phoneNumber));
    }

    public async Task<TPerson?> GetAsync(PhoneNumber phoneNumber)
    {
        return await _set.SingleOrDefaultAsync(x => x.PersonalInformation.PhoneNumber.Equals(phoneNumber));
    }
}
