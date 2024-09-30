namespace Api.Controllers.Products;

public record AddProductRequest(string Name, string? Description, int QuantityInStock, decimal Amount);
