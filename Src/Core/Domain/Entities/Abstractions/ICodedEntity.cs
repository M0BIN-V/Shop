namespace Domain.Entities.Abstractions;

internal interface ICodedEntity
{
    public Guid Code { get; set; }
}
