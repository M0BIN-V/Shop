using Application.Common.Errors;
using Application.Interfaces;
using Application.Interfaces.Auth;

namespace Application.Commands.Auth;

public record LoginWithOtpCommand(PhoneNumber PhoneNumber, string Otp) : IRequest<Result<string>>;

public class LoginWithOtpHandler : IRequestHandler<LoginWithOtpCommand, Result<string>>
{
    readonly IReadCustomersRepository _readCustomersRepository;
    readonly IWriteCustomersRepository _writeCustomersRepository;
    readonly IOtpService _otpService;
    readonly IJwtService _jwtService;

    public LoginWithOtpHandler(
        IOtpService otpService,
        IJwtService jwtService,
        IReadCustomersRepository readCustomersRepository,
        IWriteCustomersRepository writeCustomersRepository)
    {
        _otpService = otpService;
        _jwtService = jwtService;
        _readCustomersRepository = readCustomersRepository;
        _writeCustomersRepository = writeCustomersRepository;
    }

    public async Task<Result<string>> Handle(LoginWithOtpCommand request, CancellationToken cancellationToken)
    {
        var otp = _otpService.GetByKey(request.PhoneNumber.Value);

        if (otp is null || otp != request.Otp)
        {
            return new Result<string>(new OtpIsNotValidError());
        }

        if (!await _readCustomersRepository.ExistsAsync(request.PhoneNumber))
        {
            var newCustomer = new Customer
            {
                PersonalInformation = new()
                {
                    PhoneNumber = request.PhoneNumber
                }
            };

            await _writeCustomersRepository.AddAsync(newCustomer);
        }

        _otpService.Deprecate(request.PhoneNumber.Value);

        var jwt = _jwtService.Generate(new() { PhoneNumber = request.PhoneNumber.Value });

        return new Result<string>(jwt);
    }
}