using Application.Errors;
using Application.Interfaces;
using Application.Interfaces.Auth;

namespace Application.Commands.Auth;

public record LoginWithOtpCommand(PhoneNumber PhoneNumber, string Otp) : IRequest<Result<string>>;

public class LoginWithOtpHandler : IRequestHandler<LoginWithOtpCommand, Result<string>>
{
    readonly IOtpService _otpService;
    readonly IJwtService _jwtService;

    public LoginWithOtpHandler(IOtpService otpService, IJwtService jwtService)
    {
        _otpService = otpService;
        _jwtService = jwtService;
    }

    public Task<Result<string>> Handle(LoginWithOtpCommand request, CancellationToken cancellationToken)
    {
        var otp = _otpService.GetByKey(request.PhoneNumber.Value);

        if (otp is null || otp != request.Otp)
        {
            return new Result<string>(new OtpIsNotValidError());
        }

        _otpService.Deprecate(request.PhoneNumber.Value);

        var jwt = _jwtService.Generate(new() { PhoneNumber = request.PhoneNumber.Value });

        return new Result<string>(jwt);
    }
}