namespace PersistenceTests.Repositories.Read.Abstractions;

public interface IReadPersonRoleRepositoryTests : IReadRepositoryBaseTests
{
    public Task GetByPhoneNumber_WhenExists_ShouldReturnEntity();

    public Task GetByPhoneNumber_WhenNotExists_ShouldReturnNull();

    public Task ExistsByPhoneNumber_WhenCustomerExists_ShouldReturnTrue();

    public Task ExistsByPhoneNumber_WhenCustomerNotExists_ShouldReturnFalse();
}
