namespace petFamily.Domain.Shared.IDs;

public record BreedId
{
    private BreedId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public static Guid NewBreedId() => Guid.NewGuid();
    public static BreedId Empty => new (Guid.Empty);
    public static BreedId Create(Guid id) => new(id);
}