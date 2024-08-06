using Application.Common.Dtos;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;
using Domain.ValueObjects;
using MediatR;
using Resulver;

namespace Application.Commands.Auth;

public record RegisterCustomerCommand(PhoneNumber PhoneNumber) : IRequest<Result<ViewRegisterResult>>;

public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Result<ViewRegisterResult>>
{
    IWriteCustomersRepository _writeCustomers;
    IReadCustomersRepository _readCustomers;

    public RegisterCustomerCommandHandler(IReadCustomersRepository readCustomers, IWriteCustomersRepository writeCustomers)
    {
        _writeCustomers = writeCustomers;
        _readCustomers = readCustomers;
    }

    public Task<Result<ViewRegisterResult>> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _readCustomers.Get(request.PhoneNumber);

        throw new NotImplementedException();
    }
}