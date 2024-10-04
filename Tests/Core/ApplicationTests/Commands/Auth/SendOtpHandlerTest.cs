using Application.Commands.Auth;
using Application.Interfaces;

namespace ApplicationTests.Commands.Auth;

public class SendOtpHandlerTest
{
    readonly Mock<ISmsService> _smsServiceMock = new();
    readonly SendOtpHandler _handler;
    readonly Mock<IOtpService> _otpServiceMock = new();
    readonly PhoneNumber _phoneNumber = PhoneNumber.Create("09666666666")!;

    public SendOtpHandlerTest()
    {
        _otpServiceMock.Setup(x => x.GenerateAndSave(_phoneNumber.Value, null))
            .Returns("111111");

        _handler = new(_smsServiceMock.Object, _otpServiceMock.Object);
    }

    [Fact]
    public async Task HandleTest()
    {
        var result = await _handler.Handle(new SendOtpCommand(_phoneNumber), CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }
}
