using Resulver;

namespace Domain.Errors;

public class ValidationError : ResultError
{
    public ValidationError(string message, string? title = null) : base(message, title) { }
}
