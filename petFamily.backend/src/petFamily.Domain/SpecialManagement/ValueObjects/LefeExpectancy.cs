using petFamily.Domain.Shared;

namespace petFamily.Domain.SpecialManagement.ValueObjects;

public record LifeExpectancy
{
    private const int MIN_YEAR = 0;
    private const int MAX_YEAR = 200;

    private LifeExpectancy(int lifeExpectancy)
    {
        this.lifeExpectancy  = lifeExpectancy ;
    }
    public int lifeExpectancy  { get;}

    public static Result<LifeExpectancy> Create(int year)
    {
        if (year < MIN_YEAR || year > MAX_YEAR)
            return "Invalid year";
        return new LifeExpectancy(year);
    }
}