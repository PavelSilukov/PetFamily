using System.Linq;
using petFamily.Domain.Shared;

namespace petFamily.Domain.Volunteers;

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

    public static Result<Gender> Create(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "Gender is not null or empty";
        var gender = input.Trim().ToLower();
        if (_all.Any(g => g.Value.ToLower() == gender) == false)
            return "Gender is not valid";
        return new Gender(input);
    }
}