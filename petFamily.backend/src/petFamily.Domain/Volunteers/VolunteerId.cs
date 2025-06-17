namespace petFamily.Domain.Volunteers;

public record VolunteerId
{
    private VolunteerId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    public static Guid NewVunteerId() => Guid.NewGuid();
    public static VolunteerId Empty => new (Guid.Empty);
};