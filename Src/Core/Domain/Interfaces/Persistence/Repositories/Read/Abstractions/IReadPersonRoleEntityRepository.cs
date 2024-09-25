using Domain.Entities.Abstractions;

namespace Domain.Interfaces.Persistence.Repositories.Read.Abstractions;

public interface IReadPersonRoleEntityRepository<TPerson> : ICodedEntityRepository<TPerson>
    where TPerson : PersonRoleEntityBase
{
    public Task<TPerson?> GetAsync(PhoneNumber phoneNumber);
    public Task<bool> ExistsAsync(PhoneNumber phoneNumber);
}