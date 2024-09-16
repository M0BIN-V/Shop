using Application.Commands.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ResultBaseController
{
    readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("send-otp")]
    [ProducesResponseType<ResponseTemplate>(200)]
    public async Task<IActionResult> SendOtp(SendOtpRequest request)
    {
        var phoneNumberValueObject = new PhoneNumber { Value = request.PhoneNumber };

        var command = new SendOtpCommand(phoneNumberValueObject);

        var result = await _mediator.Send(command);

        return FromResult(result);
    }

    [HttpPost("login-with-otp")]
    [ProducesResponseType<ResponseTemplate<string>>(Status200OK)]
    public async Task<IActionResult> LoginWithOtp(LoginWithOtpRequest request)
    {
        var command = new LoginWithOtpCommand(
            new PhoneNumber { Value = request.PhoneNumber }, request.Otp);

        var result = await _mediator.Send(command);

        return FromResult(result);
    }
}
