using Resulver;

namespace Domain.Errors;

public class CustomerNotFoundError() : ResultError("Customer not found");
public class CustomerAlreadyExistsError() : ResultError("Customer already exists");