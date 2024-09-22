using Domain.Entities.Abstractions;

namespace Domain.Entities.ProductEntities;

public class Price : EntityBase
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}