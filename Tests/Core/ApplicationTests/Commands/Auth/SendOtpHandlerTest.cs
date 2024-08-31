using Application.Commands.Auth;
using Application.Interfaces;
using Domain.Errors;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.ValueObjects;

namespace ApplicationTests.Commands.Auth;

public class SendOtpHandlerTest
{
    readonly Mock<IReadCustomersRepository> _readCustomerRepositoryMock = new();
    readonly Mock<ISmsService> _smsServiceMock = new();
    readonly SendOtpHandler _handler;
    readonly Mock<IOtpService> _otpServiceMock = new();

    public SendOtpHandlerTest()
    {
        _handler = new(_readCustomerRepositoryMock.Object, _smsServiceMock.Object, _otpServiceMock.Object);
    }

    [Fact]
    public async Task SendOtpHandler_WithNotExistsPhoneNumber_ShouldReturnFailureResult()
    {
        var phoneNumber = new PhoneNumber { Value = "09111111111" };

        _readCustomerRepositoryMock.Setup(r => r.ExistsAsync(phoneNumber)).Returns(Task.FromResult(false));

        var result = await _handler.Handle(new SendOtpCommand(phoneNumber), CancellationToken.None);

        result.IsFailure.Should().BeTrue();

        result.Errors.Any(e => e is CustomerNotFoundError).Should().BeTrue();
    }

    [Fact]
    public async Task SendOtpHandler_WithExistsPhoneNumber_ShouldReturnSuccessResult()
    {
        var phoneNumber = new PhoneNumber { Value = "06665988888" };

        _readCustomerRepositoryMock.Setup(r => r.ExistsAsync(phoneNumber)).Returns(Task.FromResult(true));

        var result = await _handler.Handle(new SendOtpCommand(phoneNumber), CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }
}
