using Application.Commands.Customers;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;
using Domain.ValueObjects;

namespace ApplicationTests.Commands.Customers;

public class RegisterCustomerHandlerTest
{
    readonly Mock<IReadCustomersRepository> _readRepositoryMock = new();
    readonly Mock<IWriteCustomersRepository> _writeRepositoryMock = new();
    readonly RegisterCustomerHandler _handler;

    public RegisterCustomerHandlerTest()
    {
        _handler = new(_readRepositoryMock.Object, _writeRepositoryMock.Object);
    }

    [Fact]
    public async Task RegisterCustomerTest_withNewCustomer_ShouldReturnSuccessResult()
    {
        var request = new RegisterCustomerCommand(new PhoneNumber { Value = "09366656565" });

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task RegisterCustomerTest_withExistCustomer_ShouldReturnFailure()
    {
        var request = new RegisterCustomerCommand(new PhoneNumber { Value = "09366656565" });

        _readRepositoryMock.Setup(x => x.ExistsAsync(request.PhoneNumber)).Returns(Task.FromResult(true));

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
    }
}
