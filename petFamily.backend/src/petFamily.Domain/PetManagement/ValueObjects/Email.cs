using System.Text.RegularExpressions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public class Email
{
    private Email(string emailValue)
    {
        EmailValue = emailValue;
    }
    public string EmailValue { get; }
    private const string EmailRegex = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$ ";
    
    public static Result<Email> Create(string input)
    {
        if  (string.IsNullOrEmpty(input))
            return "Number cannot be null or empty";
        if(Regex.IsMatch(input, EmailRegex) == false)
            return "Invalid phone number";
        return new Email(input);
    }
}