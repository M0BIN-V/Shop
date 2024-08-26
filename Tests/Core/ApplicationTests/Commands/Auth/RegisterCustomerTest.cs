using Application.Commands.Auth;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;
using Domain.ValueObjects;

namespace ApplicationTests.Commands.Auth;

public class RegisterCustomerTest
{
    readonly Mock<IReadCustomersRepository> _readRepositoryMock = new();
    readonly Mock<IWriteCustomersRepository> _writeRepositoryMock = new();
    readonly RegisterCustomerHandler _handler;

    public RegisterCustomerTest()
    {
        _handler = new(_readRepositoryMock.Object, _writeRepositoryMock.Object);
    }

    [Fact]
    public async Task RegisterCustomerTest_withNewCustomer()
    {
        var request = new RegisterCustomerCommand(new PhoneNumber { Value = "09366656565" });

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task RegisterCustomerTest_withExistCustomer()
    {
        var request = new RegisterCustomerCommand(new PhoneNumber { Value = "09366656565" });

        _readRepositoryMock.Setup(x => x.ExistsAsync(request.PhoneNumber)).Returns(Task.FromResult(true));

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
    }
}
