using System;

namespace petFamily.Domain.Species;

public record SpeciesId
{
    private SpeciesId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    public static Guid NewSpecialId() => Guid.NewGuid();
    public static SpeciesId Empty => new (Guid.Empty);
}