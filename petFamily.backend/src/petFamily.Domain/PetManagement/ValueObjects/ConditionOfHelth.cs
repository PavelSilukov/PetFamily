using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record ConditionOfHealth
{
    private ConditionOfHealth(string description )
    {
        Description = description ;
    }
    public string Description { get; }

    public static Result<ConditionOfHealth> Create(string description)
    {
        if (string.IsNullOrEmpty(description))
            return "Description or health not be null or empty";

        return new ConditionOfHealth(description);
    }
}