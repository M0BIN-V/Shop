namespace Application.Commands.Customers;

public record RegisterCustomerCommand(PhoneNumber PhoneNumber) : IRequest<Result<Guid>>;

public class RegisterCustomerHandler : IRequestHandler<RegisterCustomerCommand, Result<Guid>>
{
    readonly IWriteCustomersRepository _writeCustomers;
    readonly IReadCustomersRepository _readCustomers;

    public RegisterCustomerHandler(IReadCustomersRepository readCustomers, IWriteCustomersRepository writeCustomers)
    {
        _writeCustomers = writeCustomers;
        _readCustomers = readCustomers;
    }

    public async Task<Result<Guid>> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        if (await _readCustomers.ExistsAsync(request.PhoneNumber))
        {
            return new CustomerWithThisPhoneNumberAlreadyExistsError();
        }

        var newCustomer = new Customer
        {
            PersonalInformation = new()
            {
                PhoneNumber = request.PhoneNumber
            }
        };

       await _writeCustomers.AddAsync(newCustomer);

        return new Result<Guid>(newCustomer.Code);
    }
}