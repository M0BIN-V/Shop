using Domain.Entities;
using Domain.Errors;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;
using Domain.ValueObjects;
using MediatR;
using Resulver;

namespace Application.Commands.Auth;

public record RegisterCustomerCommand(PhoneNumber PhoneNumber) : IRequest<Result>;

internal class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Result>
{
    IWriteCustomersRepository _writeCustomers;
    IReadCustomersRepository _readCustomers;

    public RegisterCustomerCommandHandler(IReadCustomersRepository readCustomers, IWriteCustomersRepository writeCustomers)
    {
        _writeCustomers = writeCustomers;
        _readCustomers = readCustomers;
    }

    public Task<Result> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        if (_readCustomers.Exists(request.PhoneNumber))
        {
            var error = new CustomerAlreadyExistsError();
            return new Result(error);
        }

        var newCustomer = new Customer
        {
            PersonalInformation = new()
            {
                PhoneNumber = request.PhoneNumber
            }
        };

        _writeCustomers.Add(newCustomer);

        return new Result("Customer registered successfully");
    }
}