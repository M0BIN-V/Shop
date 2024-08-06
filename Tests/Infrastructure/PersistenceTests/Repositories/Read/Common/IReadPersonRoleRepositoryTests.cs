namespace PersistenceTests.Repositories.Read.Common;

public interface IReadPersonRoleRepositoryTests : IReadRepositoryBaseTests
{
    public void GetByPhoneNumber_WhenExists();

    public void GetByPhoneNumber_whenNotExists();
}
