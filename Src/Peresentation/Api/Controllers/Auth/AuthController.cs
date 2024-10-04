using Api.Common.Attributes;
using Application.Commands.Auth;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;

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
    [ResultResponse(Status200OK)]
    public async Task<IActionResult> SendOtp(SendOtpRequest request)
    {
        var phoneNumberValueObject = PhoneNumber.Create(request.PhoneNumber);

        var command = new SendOtpCommand(phoneNumberValueObject!);

        var result = await _mediator.Send(command);

        return FromResult(result);
    }

    [HttpPost("login-with-otp")]
    [ResultResponse<string>(Status200OK)]
    public async Task<IActionResult> LoginWithOtp(LoginWithOtpRequest request)
    {
        var command = new LoginWithOtpCommand(PhoneNumber.Create(request.PhoneNumber)!, request.Otp);

        var result = await _mediator.Send(command);

        return FromResult(result);
    }
}
