using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public class Email
{
    private Email(string emailValue)
    {
        EmailValue = emailValue;
    }
    public string EmailValue { get; }
    //private const string EmailRegex = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$ "; |Regex.IsMatch(input, EmailRegex) == false
    
    public static Result<Email, Error> Create(string input)
    {
        if  (string.IsNullOrEmpty(input))
            return Errors.General.ValueIsInvalid("Email");
        return new Email(input);
    }
}