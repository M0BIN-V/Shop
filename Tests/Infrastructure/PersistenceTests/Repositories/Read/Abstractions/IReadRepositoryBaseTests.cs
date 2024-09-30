namespace PersistenceTests.Repositories.Read.Abstractions;

public interface IReadRepositoryBaseTests
{
    public Task GetById_WhenExists_ShouldReturnEntity();
    public Task GetById_WhenNotExists_ShouldReturnNull();
    public Task ExistsById_WhenExists_ShouldReturnTrue();
    public Task ExistsById_WhenNotExists_ShouldReturnFalse();
}
