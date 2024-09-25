
namespace Domain.Entities.Abstractions;

public abstract class PersonRoleEntityBase : EntityBase, ICodedEntity
{
    public Guid Code { get; set; }
    public virtual required PersonalInformation PersonalInformation { get; set; }
}
