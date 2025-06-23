using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using petFamily.Domain.Enum;
using petFamily.Domain.Shared;
using petFamily.Domain.Species;

namespace petFamily.Domain.Volunteers;

public class Pet: petFamily.Domain.Shared.Entity<PetId>
{
    //ef core
    private Pet(PetId petId)
    :base (petId)
    {

    }

    private Pet(
        PetId petId, 
        string nickName, 
        Age age, 
        Gender gender, 
        Status status, 
        TypesOfPets typesOfPets,
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
    }
    
    public string Nickname { get; private set; } 
    public Age Age { get; private set; } 
    public Gender Gender { get; private set; }
    
    public string Description { get; private set; } 
    
    public string? ConditionOfHelth { get; private set; } 
    public Address Place {get; private set;} 
    public PhoneNumber PhoneNumberOwner { get; private set; } 
    public bool? IsNeutered { get; private set; } 
    public bool? IsVaccinated { get; private set; } 
    public Status Status { get; private set; } 
    public Requisite Requisite { get; private set; }
    public DateTime DateOfCreate => DateTime.Now;
    
    public SpecialAndBreed SpecialAndBreed { get; private set; }


    public static Result<Pet> Create(
        PetId petId,
        string nickName,
        Age age,
        Gender gender,
        Status status,
        TypesOfPets typesOfPets,
        Address address,
        PhoneNumber phoneNumberOwner,
        bool isNeutered,
        bool isVaccinated,
        Requisite requisite,
        SpecialAndBreed specialAndBreed
    )
    {
        if(string.IsNullOrWhiteSpace(nickName))
            return "Nickname cannot be null or whitespace.";
        return new Pet(
            petId, 
            nickName, 
            age, 
            gender, 
            status, 
            typesOfPets,
            address,
            phoneNumberOwner,
            isNeutered, 
            isVaccinated, 
            requisite,
            specialAndBreed);
    }
}

