using petFamily.Domain.PetManagement.Enum;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;
using petFamily.Domain.SpecialManagement.Enum;
using petFamily.Domain.SpecialManagement.ValueObjects;

namespace petFamily.Domain.SpecialManagement.Entities;

public class Species : petFamily.Domain.Shared.Entity<SpeciesId>
{
     private readonly List<Breed> _breeds = [];
     //Ef
     private Species(SpeciesId id)
          :base(id)
     {
          
     }
     private Species(
          SpeciesId specialId,
          Description description,
          Parameters parameters,
          TypesOfPets typesOfPets,
          TypeOfFood typeOfFood,
          Appointment appointment
          )
     :base(specialId)
     {
          Description = description;
          Parameters = parameters;
          TypeOfFood = typeOfFood;
          Appointment = appointment;
     }
     public Description Description {get; private set;}
     public Parameters Parameters { get; private set; }

     public TypeOfFood TypeOfFood { get; private set; }
     
     //Назначение
     public Appointment Appointment { get; private set; }
    
     public IReadOnlyList<Breed> Breeds => _breeds;
     
}
