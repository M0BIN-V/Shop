using Domain.Entities.Abstractions;
using Domain.Entities.ProductEntities;

namespace Domain.Entities.Product;

public class Product : EntityBase, ICodedEntity
{
    public Guid Code { get; set; }
    public required Name Name { get; set; }
    public virtual List<Picture> Pictures { get; set; } = [];
    public Description? Description { get; set; }
    public virtual required List<Price> Prices { get; set; }
    public required int StockQuantity { get; set; }
    public virtual List<Specification> Specifications { get; set; } = [];
    public virtual List<Comment> Comments { get; set; } = [];
    public virtual List<Rate> Rates { get; set; } = [];
}