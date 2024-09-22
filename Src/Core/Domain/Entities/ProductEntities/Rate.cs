using Domain.Entities.Abstractions;

namespace Domain.Entities.ProductEntities;

public class Rate : EntityBase
{
    public virtual required Customer Rater { get; set; }
    public required ProductRate RatePercentage { get; set; }
}