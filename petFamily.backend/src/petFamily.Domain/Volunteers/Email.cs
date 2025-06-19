using System.Text.RegularExpressions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.Volunteers;

public class Email
{
    public string EmailValue { get; }
    private const string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$ ";

    private Email(string email)
    {
        EmailValue= email;
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