using petFamily.Domain.PetManagement.Enum;
using petFamily.Domain.PetManagement.ValueObjects;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;

namespace petFamily.Domain.PetManagement.Entities;

public class Pet: petFamily.Domain.Shared.Entity<PetId>
{
    //ef core

    private Pet(PetId id) : base(id)
    {
    }

    private Pet(
        PetId petId, 
        NickName nickName, 
        Age age, 
        Gender gender, 
        Status status, 
        TypesOfPets typesOfPets,
        ConditionOfHealth conditionOfHealth,
        Address address,
        PhoneNumber phoneNumberOwner,
        bool isNeutered,
        bool isVaccinated,
        Requisite requisite, 
        SpecialAndBreed  specialAndBreed
        )
    :base(petId)
    {
        Nickname = nickName;
        Age = age;
        Gender = gender;
        Status = status;
        Place = address;
        IsNeutered = isNeutered;
        IsVaccinated = isVaccinated;
        Requisite = requisite;
        PhoneNumberOwner = phoneNumberOwner;
        SpecialAndBreed = specialAndBreed;
        TypesOfPets = typesOfPets;
        ConditionOfHealth = conditionOfHealth;
    }
    
    public NickName Nickname { get; private set; } 
    public Age Age { get; private set; } 
    public Gender Gender { get; private set; }
    
    public TypesOfPets TypesOfPets {get; private set;}
    
    public ConditionOfHealth ConditionOfHealth { get; private set; } 
    public Address Place {get; private set;} 
    public PhoneNumber PhoneNumberOwner { get; private set; } 
    public bool IsNeutered { get; private set; } 
    public bool IsVaccinated { get; private set; } 
    public Status Status { get; private set; } 
    public Requisite Requisite { get; private set; }
    public DateTime DateOfCreate => DateTime.Now;
    
    public SpecialAndBreed SpecialAndBreed { get; private set; }
}

