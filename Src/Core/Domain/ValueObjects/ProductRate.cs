
namespace Domain.ValueObjects;

public sealed class ProductRate : SingleValueObject<ProductRate, double>, ICreatableValueObject<ProductRate, double>
{
    [CustomMinLength(0)]
    [CustomMaxLength(100)]
    public override double Value => base.Value;

    private ProductRate(double value) : base(value) { }

    public static Result<ProductRate> Create(double value)
    {
        return new ProductRate(value);
    }
}