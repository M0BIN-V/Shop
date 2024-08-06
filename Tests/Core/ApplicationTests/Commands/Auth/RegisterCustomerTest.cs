using Application.Commands.Auth;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;
using Domain.ValueObjects;

namespace ApplicationTests.Commands.Auth;

public class RegisterCustomerTest
{
    [Fact]
    public async void RegisterCustomerTest_withNewCustomer()
    {
        var request = new RegisterCustomerCommand(new PhoneNumber { Value = "09366656565" });

        var readRepositoryMock = new Mock<IReadCustomersRepository>();

        var writeRepositoryMock = new Mock<IWriteCustomersRepository>();

        var handler = new RegisterCustomerCommandHandler(readRepositoryMock.Object, writeRepositoryMock.Object);

        var result = await handler.Handle(request, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async void RegisterCustomerTest_withExistCustomer()
    {
        var request = new RegisterCustomerCommand(new PhoneNumber { Value = "09366656565" });

        var readRepositoryMock = new Mock<IReadCustomersRepository>();
        readRepositoryMock.Setup(x => x.Exists(request.PhoneNumber)).Returns(true);

        var writeRepositoryMock = new Mock<IWriteCustomersRepository>();

        var handler = new RegisterCustomerCommandHandler(readRepositoryMock.Object, writeRepositoryMock.Object);

        var result = await handler.Handle(request, CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
    }
}
