using Domain.Entities.Abstractions;

namespace Domain.Entities;

public class Picture : EntityBase
{
    public required Title Name { get; set; }
    public required FilePath Path { get; set; }
}