using System.Text.RegularExpressions;

namespace petFamily.Domain.Shared;

public record PhoneNumber
{
    public string Number { get; }
    private const string phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

    private PhoneNumber(string Number)
    {
        this.Number = Number;
    }

    public static Result<PhoneNumber> Create(string phoneNumber)
    {
        if  (string.IsNullOrEmpty(phoneNumber))
            return "Number cannot be null or empty";
        if(Regex.IsMatch(phoneNumber, phoneRegex) == false)
            return "Invalid phone number";
        return new PhoneNumber(phoneNumber);
    }
}