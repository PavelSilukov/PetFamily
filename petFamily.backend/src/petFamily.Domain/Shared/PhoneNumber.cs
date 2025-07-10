using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace petFamily.Domain.Shared;

public record PhoneNumber
{
    public string Number { get; }
    private const string phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

    private PhoneNumber(string Number)
    {
        this.Number = Number;
    }

    public static Result<PhoneNumber, Error> Create(string phoneNumber)
    {
        if  (string.IsNullOrEmpty(phoneNumber)||Regex.IsMatch(phoneNumber, phoneRegex) == false)
            return Errors.General.ValueIsInvalid("Phone Number");
 
        return new PhoneNumber(phoneNumber);
    }
}