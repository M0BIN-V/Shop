namespace Application.Common.Dtos;

public class AddProductDto
{
    public required Name Name { get; set; }
    public Description? Description { get; set; }
    public required decimal Amount { get; set; }
    public required int StockQuantity { get; set; }
    public List<AddSpecificationDto> Specifications { get; set; } = [];
}