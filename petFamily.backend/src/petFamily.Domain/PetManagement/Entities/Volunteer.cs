using petFamily.Domain.PetManagement.Enum;
using petFamily.Domain.PetManagement.ValueObjects;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;

namespace petFamily.Domain.PetManagement.Entities;

public class Volunteer : petFamily.Domain.Shared.Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];
    // ef
    private Volunteer(VolunteerId id)
    : base(id)
    {

    }

    public Volunteer(
        VolunteerId volunteerId,
        FullName fullName, 
        Email email, 
        PhoneNumber phoneNumber,
        Description description, 
        ExperienceYears experienceYears,
        Address address,
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
        Address = address;
        Requisite = requisite;
        VolunteerSocialNets = volunteerSocialNets;
    }
    public FullName FullName { get; private set; } 
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set;}
    public Description Description { get; private set; } 
    
    public ExperienceYears ExperienceYears { get; private set;} 
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
}
