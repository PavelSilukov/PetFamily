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
        Requisite requisite,
        VolunteerSocialNets volunteerSocialNets
        )
    : base(volunteerId)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        Description = description;
        ExperienceYears = experienceYears;
        Requisite = requisite;
        VolunteerSocialNets = volunteerSocialNets;
    }
    public FullName FullName { get; private set; } 
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set;}
    public string Description { get; private set; } 
    
    public int ExperienceYears { get; private set;} 
    public Address Address { get; private set; } 
    public VolunteerSocialNets VolunteerSocialNets{ get; private set; }
    public IReadOnlyList<Pet> pets => _pets;
    public int GetNumberOfPets() => _pets.Count;
    
    public int GetQuantityPetsFoundHome()
    {
        return _pets.Count(p => p.Status == Status.FoundHome);
    }

    public int GetQuantityOfPetLookingForHome()
    {
        return _pets.Count(p => p.Status == Status.LookingForHome);
    }
    public int GetQuantityOfPetNeedsHelp()
    {
        return _pets.Count(p => p.Status == Status.NeedsHelp);
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
        Requisite requisite,
        VolunteerSocialNets volunteerSocialNets)
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
            requisite,
            volunteerSocialNets);
    }
}
