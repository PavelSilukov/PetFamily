using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record FullName
{
    private FullName(string Name, string Surname, string? SecondName)
    {
        this.Name = Name;
        this.Surname = Surname;
        this.SecondName = SecondName;
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