using petFamily.Domain.Enum;
using petFamily.Domain.Shared;
using petFamily.Domain.Species;
using petFamily.Domain.Volunteers;


namespace petFamily.Domain.Species;

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
          Parameters parameters,
          TypesOfPets typesOfPets,
          TypeOfFood typeOfFood,
          string conditionsOfDetention,
          Appointment appointment,
          Guid breedId
          )
     :base(specialId)
     {
          Parameters = parameters;
          TypesOfPets = typesOfPets;
          TypeOfFood = typeOfFood;
          ConditionsOfDetention = conditionsOfDetention;
          Appointment = appointment;

     }
     
     public Parameters? Parameters { get; private set; }
     public TypesOfPets TypesOfPets { get; private set; }

     public TypeOfFood TypeOfFood { get; private set; }
     //Условия содержания
     public string? ConditionsOfDetention  { get; private set; }
     
     //Назначение
     public Appointment Appointment { get; private set; }
    
     public IReadOnlyList<Breed> Breeds => _breeds;

     public static Result<Species> Create(
          SpeciesId speciesId,
          Parameters parameters,
          TypesOfPets typesOfPets,
          TypeOfFood typeOfFood,
          string conditionsOfDetention,
          Appointment apointment,
          Guid breedId)
     {
          return new Species(
               speciesId,
               parameters,
               typesOfPets,
               typeOfFood,
               conditionsOfDetention,
               apointment,
               breedId
          );
     }
}
