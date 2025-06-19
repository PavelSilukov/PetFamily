using petFamily.Domain.Enum;
using petFamily.Domain.Shared;

namespace petFamily.Domain.Volunteers;

public class Volunteer : petFamily.Domain.Shared.Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];
    // ef
    private Volunteer(VolunteerId id)
    : base(id)
    {

    }

    private Volunteer(
        VolunteerId volunteerId,
        FullName fullName, 
        Email email, 
        PhoneNumber phoneNumber,
        string description, 
        int experienceYears,
        Requisite requisite
        )
    : base(volunteerId)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        Description = description;
        ExperienceYears = experienceYears;
        Requisite = requisite;
        
    }
    public VolunteerId Id { get; private set; } 
    public FullName FullName { get; private set; } 
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set;}
    public string Description { get; private set; } 
    
    public int ExperienceYears { get; private set;} 
    public Address Address { get; private set; } 
    public IReadOnlyList<Pet> pets => _pets;
    public int GetNumberOfPets() => _pets.Count;
    
    public List<Pet> getPetsFoundHome()
    {
        return _pets.Where(p => p.status == Status.FoundHome).ToList();
    }

    public List<Pet> LookingForHome()
    {
        return _pets.Where(p => p.status == Status.LookingForHome).ToList();
    }
    public List<Pet> NeedsHelp()
    {
        return _pets.Where(p => p.status == Status.NeedsHelp).ToList();
    }
    public Requisite Requisite { get; set; }

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
    }
    

    public static Result<Volunteer> Create(
        VolunteerId volunteerId, 
        FullName fullName, 
        Email email, 
        PhoneNumber phoneNumber,
        string description, 
        int experienceYears,
        Requisite requisite)
    {
        if (string.IsNullOrWhiteSpace(description))
            return "Description cannot be empty";
        if (experienceYears <= 0)
            return "Experience Years cannot be negative"; 
        return new Volunteer(
            volunteerId, 
            fullName, 
            email, 
            phoneNumber, 
            description, 
            experienceYears, 
            requisite);
    }
}
