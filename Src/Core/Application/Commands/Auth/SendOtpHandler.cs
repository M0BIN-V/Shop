using Application.Interfaces;

namespace Application.Commands.Auth;

public record SendOtpRequest(PhoneNumber PhoneNumber) : IRequest<Result>;

public class SendOtpHandler : IRequestHandler<SendOtpRequest, Result>
{
    readonly IReadCustomersRepository _customersRepository;
    readonly ISmsService _smsService;
    readonly IOtpService _otpService;

    public SendOtpHandler(
        IReadCustomersRepository repository,
        ISmsService smsService,
        IOtpService otpService)
    {
        _smsService = smsService;
        _customersRepository = repository;
        _otpService = otpService;
    }

    public async Task<Result> Handle(SendOtpRequest request, CancellationToken cancellationToken)
    {
        if (!await _customersRepository.ExistsAsync(request.PhoneNumber))
        {
            return new CustomerNotFoundError();
        }

        var otp = _otpService.Generate(request.PhoneNumber.Value);

        await _smsService.SendOtpAsync(request.PhoneNumber, otp);

        return new Result();
    }
}