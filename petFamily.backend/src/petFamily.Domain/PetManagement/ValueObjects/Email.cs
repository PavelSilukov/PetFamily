using System.Text.RegularExpressions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public class Email
{
    public string EmailValue { get; }
    private const string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$ ";

    private Email(string EmailValue)
    {
        this.EmailValue= EmailValue;
    }

    public static Result<Email> Create(string input)
    {
        if  (string.IsNullOrEmpty(input))
            return "Number cannot be null or empty";
        if(Regex.IsMatch(input, emailRegex) == false)
            return "Invalid phone number";
        return new Email(input);
    }
}