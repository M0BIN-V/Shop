﻿namespace Application.Commands.Auth;

public record RegisterCustomerCommand(PhoneNumber PhoneNumber) : IRequest<Result<Guid>>;

public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Result<Guid>>
{
    readonly IWriteCustomersRepository _writeCustomers;
    readonly IReadCustomersRepository _readCustomers;

    public RegisterCustomerCommandHandler(IReadCustomersRepository readCustomers, IWriteCustomersRepository writeCustomers)
    {
        _writeCustomers = writeCustomers;
        _readCustomers = readCustomers;
    }

    public Task<Result<Guid>> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        if (_readCustomers.Exists(request.PhoneNumber))
        {
            var error = new CustomerAlreadyExistsError();
            return new Result<Guid>(error);
        }

        var newCustomer = new Customer
        {
            PersonalInformation = new()
            {
                PhoneNumber = request.PhoneNumber
            }
        };
        
        _writeCustomers.Add(newCustomer);

        return new Result<Guid>(newCustomer.Code);
    }
}