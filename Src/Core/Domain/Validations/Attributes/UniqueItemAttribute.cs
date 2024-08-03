using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Domain.Validations.Attributes;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class UniqueItemAttribute : ValidationAttribute
{
    readonly string? uniquePropertyName;

    public UniqueItemAttribute(string? uniqueProperty = null,
        string errorMessage = "The collection must contain unique items based on a unique value")
    {
        uniquePropertyName = uniqueProperty;
        ErrorMessage = errorMessage;
    }

    public override bool IsValid(object? value)
    {
        if (value is IEnumerable collection)
        {
            var list = collection.Cast<object>().ToList();
            if (list.Count != list.Distinct().Count())
            {
                return false;
            }
        }
        return true;
    }
}
