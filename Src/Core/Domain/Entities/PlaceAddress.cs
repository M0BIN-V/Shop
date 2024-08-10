using Domain.Entities.Abstractions;

namespace Domain.Entities;

public class PlaceAddress : EntityBase
{
    public required Address Address { get; set; }

    public required PostalCode PostalCode { get; set; }
}
