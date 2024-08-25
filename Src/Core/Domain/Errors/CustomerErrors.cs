using Resulver;

namespace Domain.Errors;

public class CustomerNotFountError() : ResultError("Customer not found");
public class CustomerAlreadyExistsError() : ResultError("Customer already exists");