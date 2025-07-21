using CSharpFunctionalExtensions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record Gender
{
    public static readonly Gender Male = new(nameof(Male));
    public static readonly Gender Female = new (nameof(Female));
    
    private static readonly Gender[] _all = [Male, Female];
   
    public string Value { get; }

    private Gender(string value)
    {
        Value = value;
    }

    public static Result<Gender, Error> Create(string input)
    {
        if (string.IsNullOrEmpty(input))
            return Errors.General.ValueIsInvalid("Gender");
        var gender = input.Trim().ToLower();
        if (_all.Any(g => g.Value.ToLower() == gender) == false)
            return Errors.General.ValueIsInvalid("Gender");
        return new Gender(input);
    }
}