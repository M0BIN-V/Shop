using Application.Interfaces;

namespace Application.Commands.Auth;

public record SendOtpCommand(PhoneNumber PhoneNumber) : IRequest<Result>;

public class SendOtpHandler : IRequestHandler<SendOtpCommand, Result>
{
    readonly ISmsService _smsService;
    readonly IOtpService _otpService;

    public SendOtpHandler(
        ISmsService smsService,
        IOtpService otpService)
    {
        _smsService = smsService;
        _otpService = otpService;
    }

    public async Task<Result> Handle(SendOtpCommand request, CancellationToken cancellationToken)
    {
        var otpResult = _otpService.GenerateAndSave(request.PhoneNumber.Value);

        if (otpResult.IsFailure)
        {
            return otpResult.Errors[0];
        }

        await _smsService.SendOtpAsync(request.PhoneNumber, otpResult.Content??throw new NullReferenceException("Otp is null"));

        return new Result($"رمز یک بار مصرف به شماره {request.PhoneNumber} ارسال شد.");
    }
}