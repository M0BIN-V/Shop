using Application.Commands.Auth;
using Application.Errors;
using Application.Interfaces;
using Application.Interfaces.Auth;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;

namespace ApplicationTests.Commands.Auth;

public class LoginWithOtpHandlerTest
{
    readonly LoginWithOtpHandler _handler;
    readonly Mock<IReadCustomersRepository> _readCustomerRepository = new();
    readonly Mock<IWriteCustomersRepository> _writeCustomerRepository = new();
    readonly Mock<IOtpService> _otpService = new();
    readonly Mock<IJwtService> _jwtService = new();
    readonly PhoneNumber _phoneNumber = new() { Value = "09122245444" };
    const string _requestOtp = "111111";
    readonly LoginWithOtpCommand _request;

    public LoginWithOtpHandlerTest()
    {
        _request = new(_phoneNumber, _requestOtp);

        _handler = new LoginWithOtpHandler(
            _otpService.Object,
            _jwtService.Object,
            _readCustomerRepository.Object,
            _writeCustomerRepository.Object);
    }

    [Fact]
    public async Task LoginWithOtpHandler_WithInvalidPhoneNumber_ShouldReturnOtpIsNotValidError()
    {
        _otpService.Setup(x => x.GetByKey(_phoneNumber.Value))
            .Returns(() => null);

        var result = await _handler.Handle(_request, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Errors[0].GetType().Should().Be(typeof(OtpIsNotValidError));
    }

    [Fact]
    public async Task LoginWithOtpHandler_WithInvalidOtp_ShouldReturnOtpIsNotValidError()
    {
        _otpService.Setup(x => x.GetByKey(_phoneNumber.Value))
            .Returns("222222");

        var result = await _handler.Handle(_request, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Errors[0].GetType().Should().Be(typeof(OtpIsNotValidError));
    }

    [Fact]
    public async Task LoginWithOtpHandler_WithValidOtp_ShouldReturnJwt()
    {
        _otpService.Setup(x => x.GetByKey(_phoneNumber.Value))
            .Returns(_requestOtp);

        var result = await _handler.Handle(_request, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
        result.Content.Should().BeNullOrEmpty();
    }
}
