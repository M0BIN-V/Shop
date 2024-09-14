using System.ComponentModel.DataAnnotations;

namespace Domain.Validations.Attributes;

public class CustomMinLengthAttribute : MinLengthAttribute
{
    public CustomMinLengthAttribute(int length) : base(length)
    {
        ErrorMessage = "{0} نمیتواند کم تر از {1} کاراکتر باشد";
    }
}

public class CustomMaxLengthAttribute : MaxLengthAttribute
{
    public CustomMaxLengthAttribute(int length) : base(length)
    {
        ErrorMessage = "{0} نمیتواند بیشتر تر از {1} کاراکتر باشد";
    }
}