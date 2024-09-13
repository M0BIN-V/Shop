using Application.Commands.Customers;
using Microsoft.AspNetCore.Mvc;
using Resulver.AspNetCore.WebApi;

namespace Api.Controllers;

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
    [ProducesResponseType<Guid>(Status201Created)]
    public async Task<IActionResult> Register([FromBody] string phoneNumber)
    {
        var command = new RegisterCustomerCommand(new PhoneNumber { Value = phoneNumber });

        var result = await _mediator.Send(command);

        return FromResult(result, () => Created("", result.Content));
    }

}
