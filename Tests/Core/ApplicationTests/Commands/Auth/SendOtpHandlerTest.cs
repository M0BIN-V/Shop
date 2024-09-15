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
    readonly PhoneNumber _phoneNumber = new() { Value = "09111111111" };

    public SendOtpHandlerTest()
    {
        _otpServiceMock.Setup(x => x.GenerateAndSave(_phoneNumber.Value, null))
            .Returns("111111");

        _handler = new(_readCustomerRepositoryMock.Object, _smsServiceMock.Object, _otpServiceMock.Object);
    }

    [Fact]
    public async Task SendOtpHandler_WithNotExistsPhoneNumber_ShouldReturnFailureResult()
    {
        _readCustomerRepositoryMock.Setup(r => r.ExistsAsync(_phoneNumber)).Returns(Task.FromResult(false));

        var result = await _handler.Handle(new SendOtpCommand(_phoneNumber), CancellationToken.None);

        result.IsFailure.Should().BeTrue();

        result.Errors.Any(e => e is CustomerNotFoundError).Should().BeTrue();
    }

    [Fact]
    public async Task SendOtpHandler_WithExistsPhoneNumber_ShouldReturnSuccessResult()
    {
        _readCustomerRepositoryMock.Setup(r => r.ExistsAsync(_phoneNumber)).Returns(Task.FromResult(true));

        var result = await _handler.Handle(new SendOtpCommand(_phoneNumber), CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }
}
