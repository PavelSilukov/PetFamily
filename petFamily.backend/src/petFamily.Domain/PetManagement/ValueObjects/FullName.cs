using CSharpFunctionalExtensions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record FullName
{
    private FullName(string name, string surname, string? secondName)
    {
        Name = name;
        Surname = surname;
        SecondName = secondName;
    }
    public string Name { get; }
    public string Surname { get;}
    public string? SecondName { get; }

    public static Result<FullName, Error> Create(string name, string surname, string? secondName)
    {
        if (string.IsNullOrEmpty(name) || (string.IsNullOrEmpty(surname)))
        {
            return Errors.General.ValueIsInvalid("Name or Surname");
        }

        return new FullName(name, surname, secondName);
    }
}