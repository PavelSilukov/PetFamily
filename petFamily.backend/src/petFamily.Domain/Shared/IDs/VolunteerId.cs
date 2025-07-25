﻿namespace petFamily.Domain.Shared.IDs;

public record VolunteerId
{
    private VolunteerId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    public static Guid NewVolunteerId() => Guid.NewGuid();
    public static VolunteerId Empty => new (Guid.Empty);
    public static VolunteerId Create(Guid id) => new(id);

    public static implicit operator Guid(VolunteerId id)
    {
        ArgumentNullException.ThrowIfNull(id);
        return id.Value;
    }
};