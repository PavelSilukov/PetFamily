using petFamily.Domain.Enum;
using petFamily.Domain.Shared;

namespace petFamily.Domain.Species;

public class Breed : petFamily.Domain.Shared.Entity<BreedId>
{
    //Ef
    private Breed(BreedId breedId)
        : base(breedId)
    {
    }
    private Breed(
        BreedId breedId,
        string name,
        ExternalSigns externalSigns,
        string temperament,
        LearningAbility learningAbility,
        int costOfMaintenancePerYearInThousandsOfRubles,
        int lefeExpectancy 
        )
        : base(breedId)
    {
        Name = name;
        ExternalSigns = externalSigns;
        Temperament = temperament;
        LearningAbility = learningAbility;
        CostOfMaintenancePerYearInThousandsOfRubles = costOfMaintenancePerYearInThousandsOfRubles;
        LifeExpectancy = lefeExpectancy;
    }

    public string Name { get; private set; } = default!;
    //Внешние характеристики
    public ExternalSigns?   ExternalSigns { get; private set; }
    //Темперамент
    public string? Temperament {get; private set;}
    //Обучаемость
    public LearningAbility? LearningAbility {get; private set;}
    //Стоимость содержания в год тыс. руб.
    public int? CostOfMaintenancePerYearInThousandsOfRubles{get; private set;}
    //Продолжительность жизни
    public int? LifeExpectancy  { get; private set; }

    public static Result<Breed> Create(
        BreedId breedId,
        string name,
        ExternalSigns externalSigns,
        string temperament,
        LearningAbility learningAbility,
        int costOfMaintenancePerYearInThousandsOfRubles,
        int lifeExpectancy
    )
    {
        if(string.IsNullOrWhiteSpace(name))
            return "Name is cannot be null or empty";
        if(costOfMaintenancePerYearInThousandsOfRubles < 0)
            return "Cost cannot be negative";
        if(lifeExpectancy < 0)
            return "LifeExpectancy cannot be negative";
        return new Breed(
            breedId,
            name,
            externalSigns,
            temperament,
            learningAbility,
            costOfMaintenancePerYearInThousandsOfRubles,
            lifeExpectancy
            );
    }
}