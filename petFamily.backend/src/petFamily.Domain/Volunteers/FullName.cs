using petFamily.Domain.Shared;

namespace petFamily.Domain.Volunteers;

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

    public static Result<FullName> Create(string name, string surname, string? secondName)
    {
        if (string.IsNullOrEmpty(name) || (string.IsNullOrEmpty(surname)))
        {
            return "Name or surname not null or empty";
        }

        return new FullName(name, surname, secondName);
    }
}