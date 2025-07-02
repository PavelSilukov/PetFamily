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

    public static Result<Address> Create(string country, string city, string street, int numberHouse)
    {
        if (string.IsNullOrWhiteSpace(country))
            return "Country is not null or empty";
        if (string.IsNullOrWhiteSpace(city))
            return "City is not null or empty";
        if (string.IsNullOrWhiteSpace(street))
            return "Street is not null or empty";
        if (numberHouse <= 0)
            return "NumberHouse is not greater than or equal to zero";
        
        
        return new Address(country, city, street, numberHouse);
    }
}