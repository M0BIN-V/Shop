using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.Products;

public record AddProductRequest(string Name, string? Description, decimal Amount, int StockQuantity);
