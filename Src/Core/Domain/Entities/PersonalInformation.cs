namespace Domain.Entities;

public class PersonalInformation
{
    public virtual Name? FirstName { get; set; }

    public virtual Name? LastName { get; set; }

    public virtual required PhoneNumber PhoneNumber { get; set; }
}
