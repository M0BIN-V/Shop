namespace PersistenceTests.Repositories.Read.Abstractions;

public interface IReadPersonRoleRepositoryTests : IReadRepositoryBaseTests
{
    public void GetByPhoneNumber_WhenExists();

    public void GetByPhoneNumber_whenNotExists();
}
