namespace petFamily.Domain.Shared.IDs;

public record PetId
{
    private PetId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    public static Guid NewPetId() => Guid.NewGuid();
    public static PetId Empty => new (Guid.Empty);
    public static PetId Create(Guid id) => new(id);
}