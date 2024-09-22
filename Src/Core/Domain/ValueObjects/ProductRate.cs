namespace Domain.ValueObjects;

public class ProductRate : SingleValueObject<double>
{
    [CustomMinLength(0), CustomMaxLength(100)]
    public override required double Value { get => base.Value; init => base.Value = value; }
}