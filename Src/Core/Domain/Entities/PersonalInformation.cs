namespace Domain.Entities;

public class PersonalInformation
{
    public virtual required Name FirstName { get; set; }

    public virtual required Name LastName { get; set; }

    public virtual required NationalCode NationalCode { get; set; }

    public virtual required PhoneNumber PhoneNumber { get; set; }

    public virtual required PlaceAddress HomeAddress { get; set; }

    public virtual required Email Email { get; set; }

    public virtual required DateTimeOffset BirthData { get; set; }

}
