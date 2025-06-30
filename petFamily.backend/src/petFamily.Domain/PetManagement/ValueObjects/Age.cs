using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record Age
{
    private const int MIN_YEAR = 0;
    private const int MAX_YEAR = 50;
    private const int MIN_MONTH = 0;
    private const int MAX_MONTH = 12;

    private Age(int Year, int Month)
    {
        this.Year = Year;
        this.Month = Month;

    }
    public int Year { get;}
    public int Month { get; set; }

    public static Result<Age> Create(int year, int month)
    {
        if (year < MIN_YEAR || year > MAX_YEAR)
            return "Year must be between " + MIN_YEAR + " and " + MAX_YEAR;
        if (month < MIN_MONTH || month > MAX_MONTH)
            return "Month must be between " + MIN_MONTH + " and " + MAX_MONTH;
        return new Age(year, month);
    }
}