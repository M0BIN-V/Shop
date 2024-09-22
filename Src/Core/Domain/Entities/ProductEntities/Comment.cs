using Domain.Entities.Abstractions;

namespace Domain.Entities.ProductEntities;

public class Comment : EntityBase
{
    public virtual required Customer Customer { get; set; }
    public required Title Title { get; set; }
    public required Description Description { get; set; }
}