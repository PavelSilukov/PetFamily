namespace petFamily.Domain.Shared.IDs;

public record SpeciesId
{
    private SpeciesId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    public static Guid NewSpecialId() => Guid.NewGuid();
    public static SpeciesId Empty => new (Guid.Empty);
    public static SpeciesId Create(Guid id) => new(id);
}