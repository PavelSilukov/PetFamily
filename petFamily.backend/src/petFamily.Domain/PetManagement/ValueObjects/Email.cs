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
    private const string validateEmailRegex = "^\\S+@\\S+\\.\\S+$";

    public static Result<Email, Error> Create(string input)
    {
        if(!Regex.IsMatch(input, validateEmailRegex))
        {
            return Errors.General.ValueIsInvalid("Email");
        }
        return new Email(input);
    }
}