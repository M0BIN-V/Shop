namespace Domain.Entities.Common;

public abstract class PersonRoleEntityBase : EntityBase
{
    public virtual required PersonalInformation PersonalInformation { get; set; }
}
