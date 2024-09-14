using Application.Commands.Customers;
using Microsoft.AspNetCore.Mvc;
using Resulver.AspNetCore.WebApi;

namespace Api.Controllers.Customers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ResultBaseController
{
    readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        ValidationProblem();

        _mediator = mediator;
    }

    [HttpPost("register")]
    [ProducesResponseType<ResponseTemplate<Guid>>(Status201Created)]
    public async Task<IActionResult> Register(RegisterCustomerRequest request)
    {
        var command = new RegisterCustomerCommand(new PhoneNumber { Value = request.PhoneNumber });

        var result = await _mediator.Send(command);

        return FromResult(result, () => Created("", result.ToResponseTemplate()));
    }
}
