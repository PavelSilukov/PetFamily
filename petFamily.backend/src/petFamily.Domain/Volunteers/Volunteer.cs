using CSharpFunctionalExtensions;

namespace petFamily.Domain.Volunteers;

public class Volunteer : petFamily.Domain.Shared.Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];
    // ef
    private Volunteer(VolunteerId id)
    : base(id)
    {

    }

    private Volunteer(VolunteerId vuntanteerId, string description)
    : base(vuntanteerId)
    {
        Description = description;
    }
    public VolunteerId Id { get; private set; } 
    public string FIO { get; private set; } = default!; 
    public string Email { get; private set;}= default!;
    public string Description { get; private set; } = default!;
    
    public int ExperienceYears { get; private set;} = default!;
    public IReadOnlyList<Pet> pets => _pets;
    public int GetNumberOfPets() => _pets.Count;
    
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
    

    public static Result<Volunteer> Create(VolunteerId volunteerId, string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return Result.Failure<Volunteer>("Description cannot be empty");
        }

        var volunteer = new Volunteer(volunteerId, description);
        return Result.Success(volunteer);
    }
}
