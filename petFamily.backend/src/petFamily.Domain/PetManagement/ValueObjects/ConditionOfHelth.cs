using CSharpFunctionalExtensions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record ConditionOfHealth
{
    public string Value { get; }
    private ConditionOfHealth(string value)
    {
       Value = value;
    }
   

    public static Result<ConditionOfHealth, Error> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Errors.General.ValueIsInvalid("Condition Of Health");

        return new ConditionOfHealth(value);
    }
}