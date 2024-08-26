namespace PersistenceTests.Repositories.Read.Abstractions;

public interface IReadPersonRoleRepositoryTests : IReadRepositoryBaseTests
{
    public  Task GetByPhoneNumber_WhenExists();

    public  Task GetByPhoneNumber_whenNotExists();
}
