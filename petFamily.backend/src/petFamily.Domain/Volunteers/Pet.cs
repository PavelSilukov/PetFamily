using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using petFamily.Domain.Enum;

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
        Сharacteristic)
    :base(petId)
    {
        Nickname = nickName;
    }
       
    public PetId Id { get; private set; }
    public string Nickname { get; private set; } 
    public Age Age { get; private set; } 
    public Gender Gender { get; private set; }
    public TypesOfPets TypesOfPets { get; private set; }
    public string Description { get; private set; } 
    
    public string ConditionOfHelth { get; private set; } 
    public Address Place {get; private set;} 
    public Сharacteristic Сharacteristic { get; private set; }
    public PhoneNumber PhoneNumberOwner { get; private set; } 
    public DateTime BirthDate { get; private set; } 
    
    public bool IsNeutered { get; private set; } 
    public bool isVaccinated { get; private set; } 
    public Status status { get; private set; } 
    public Requisite requisite { get; private set; } 
    public DateTime DateOfCreate { get; private set; } 
    
    public Guid specialId { get; private set; }
    public string BreedName { get; private set; }
}