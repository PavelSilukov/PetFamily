using System.Text.RegularExpressions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.Volunteers;

public record PhoneNumber
{
    public string Number { get; }
    private const string phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

    private PhoneNumber(string number)
    {
        Number = number;
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