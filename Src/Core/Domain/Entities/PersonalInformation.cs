using Domain.Entities.Common;

namespace Domain.Entities;

public class PersonalInformation : EntityBase
{
    public Name? FirstName { get; set; }

    public Name? LastName { get; set; }

    public required PhoneNumber PhoneNumber { get; set; }
}
