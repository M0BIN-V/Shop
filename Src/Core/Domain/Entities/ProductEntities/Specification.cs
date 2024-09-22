using Domain.Entities.Abstractions;

namespace Domain.Entities.ProductEntities;

public class Specification : EntityBase
{
    public required Title Title { get; set; }
    public Description? Description { get; set; }
}