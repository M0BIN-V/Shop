using Resulver;

namespace Domain.Errors;

public class ProductAlreadyExistsError(string message) : ResultError(message);
