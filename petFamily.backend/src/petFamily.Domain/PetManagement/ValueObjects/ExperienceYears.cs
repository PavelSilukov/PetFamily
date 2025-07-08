using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record ExperienceYears
{
    private const int MaxExperienceYears = 100;
    private const int MinExperienceYears = 0;


    private ExperienceYears(int? experienceYear)
    {
        ExperienceYear = experienceYear;
    }
    
    public int? ExperienceYear  { get; private set; }

    public static Result<ExperienceYears> Create(int? experienceYear)
    {
        if  (experienceYear < MinExperienceYears || experienceYear > MaxExperienceYears)
            return "Invalid experience year";

        return new ExperienceYears(experienceYear);
    }
}