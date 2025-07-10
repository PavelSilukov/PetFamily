using CSharpFunctionalExtensions;

namespace petFamily.Domain.Shared;

public record Address
{
    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public int NumberHouse { get; }

    private Address(string City, string Street, string Country, int NumberHouse)
    {
        this.Country = Country;
        this.City = City;
        this.Street = Street;
        this.NumberHouse = NumberHouse;
    }

    public static Result<Address, Error> Create(string country, string city, string street, int numberHouse)
    {
        if (string.IsNullOrWhiteSpace(country))
            return Errors.General.ValueIsInvalid("Country");
        if (string.IsNullOrWhiteSpace(city))
            return Errors.General.ValueIsInvalid("City");
        if (string.IsNullOrWhiteSpace(street))
            return Errors.General.ValueIsInvalid("Street");
        if (numberHouse <= 0)
            return Errors.General.ValueIsInvalid("Number house");
        
        
        return new Address(country, city, street, numberHouse);
    }
}