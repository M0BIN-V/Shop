using Api.Common.Attributes;
using Application.Commands.Products;
using Application.Common.Dtos;
using Mapster;

namespace Api.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ResultBaseController
{
    readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ResultResponse<Guid>(Status201Created)]
    public async Task<IActionResult> Add(AddProductRequest request)
    {
        var productDto = request.Adapt<AddProductDto>();
        var command = new AddProductCommand(productDto);

        var result = await _mediator.Send(command);

        return FromResult(result, Status201Created);
    }
}
