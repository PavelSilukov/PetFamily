using CSharpFunctionalExtensions;

namespace petFamily.Domain.Volunteer;

public class Volunteer
{
    private readonly List<Pet> _pets = [];
    // ef
    private Volunteer()
    {

    }

    private Volunteer(string description)
    {
        Description = description;
    }
    public Guid Id { get; private set; }
    public string FIO { get; private set; }
    public string Email { get; private set;}
    public string Description { get; private set; } = default!;
    
    public int ExperienceYears { get; private set;}
    public IReadOnlyList<Pet> pets => _pets;
    
    public List<Pet> getPetsFoundHome()
    {
        return null;
    }

    public List<Pet> LookingForHome()
    {
        return null;
    }
    public List<Pet> NeedsHelp()
    {
        return null;
    }
    public Requisite requisite { get; set; }

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
    }
    

    public static Result<Volunteer> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return Result.Failure<Volunteer>("Description cannot be empty");
        }

        var volunteer = new Volunteer(description);
        return Result.Success(volunteer);
    }
}
