using Domain.Entities.Abstractions;

namespace Domain.Entities;

public class Customer : PersonRoleEntityBase, ICodedEntity
{
    public Guid Code { get; set; }
}
