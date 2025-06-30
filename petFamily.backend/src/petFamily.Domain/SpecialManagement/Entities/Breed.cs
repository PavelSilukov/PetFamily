using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;
using petFamily.Domain.SpecialManagement.Enum;
using petFamily.Domain.SpecialManagement.ValueObjects;

namespace petFamily.Domain.SpecialManagement.Entities;

public class Breed :Entity<BreedId>
{
    //Ef
    private Breed(BreedId id)
        : base(id)
    {
    }
    public Breed(
        BreedId breedId,
        NameOfBreed nameOfBreed,
        ExternalSigns externalSigns,
        Temperament temperament,
        LearningAbility learningAbility,
        LifeExpectancy  lifeExpectancy 
        )
        : base(breedId)
    {
        NameOfBreed  = nameOfBreed ;
        ExternalSigns = externalSigns;
        Temperament = temperament;
        LearningAbility = learningAbility;
        LifeExpectancy = lifeExpectancy;
    }

    public NameOfBreed NameOfBreed { get; private set; } 
    //Внешние характеристики
    public ExternalSigns   ExternalSigns { get; private set; }
    //Темперамент
    public Temperament Temperament {get; private set;}
    //Обучаемость
    public LearningAbility LearningAbility {get; private set;}

    //Продолжительность жизни
    public LifeExpectancy LifeExpectancy  { get; private set; }
    
}