using Application.Common.Dtos;
using Mapster;

namespace Application.Commands.Products;

public record AddProductCommand(AddProductDto Product) : IRequest<Result>;

public class AddProductHandler : IRequestHandler<AddProductCommand, Result>
{
    readonly IWriteProductRepository _writeProductRepository;
    readonly IReadProductsRepository _readProductsRepository;

    public AddProductHandler(
        IWriteProductRepository writeProductRepository,
        IReadProductsRepository readProductsRepository)
    {
        _writeProductRepository = writeProductRepository;
        _readProductsRepository = readProductsRepository;
    }

    public async Task<Result> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = request.Product.Adapt<Product>();

        if (await _readProductsRepository.ExistsAsync(request.Product.Name))
        {
            return new ProductAlreadyExistsError($"محصولی با نام {request.Product.Name} قبلا ثبت شده است.");
        }

        await _writeProductRepository.AddAsync(newProduct);

        return new Result("محصول با موفقیت ثبت شد.");
    }
}
