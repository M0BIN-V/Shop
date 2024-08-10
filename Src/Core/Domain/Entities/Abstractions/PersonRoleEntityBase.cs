namespace Domain.Entities.Abstractions;

public abstract class PersonRoleEntityBase : EntityBase
{
    public virtual required PersonalInformation PersonalInformation { get; set; }
}
