using Application.Commands.Auth;
using Microsoft.AspNetCore.Mvc;
using Resulver.AspNetCore.WebApi;

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
    public async Task<IActionResult> SendOtp(SendOtpRequest request)
    {
        var phoneNumberValueObject = new PhoneNumber { Value = request.PhoneNumber };

        var command = new SendOtpCommand(phoneNumberValueObject);

        var result = await _mediator.Send(command);

        return FromResult(result, Ok);
    }
}
