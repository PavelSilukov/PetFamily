using CSharpFunctionalExtensions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record Age
{
    private const int MIN_YEAR = 0;
    private const int MAX_YEAR = 150;
    private const int MIN_MONTH = 0;
    private const int MAX_MONTH = 12;

    private Age(int Year, int Month)
    {
        this.Year = Year;
        this.Month = Month;

    }
    public int Year { get;}
    public int Month { get; set; }

    public static Result<Age, Error> Create(int year, int month)
    {
        if (year < MIN_YEAR || year > MAX_YEAR)
            return Errors.General.ValueIsInvalid("Year");
        if (month < MIN_MONTH || month > MAX_MONTH)
            return Errors.General.ValueIsInvalid("Month");
        return new Age(year, month);
    }
}