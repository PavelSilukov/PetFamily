using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record SocialNetwork
{
    private SocialNetwork(string Name, string Url)
    {
        this.Name = Name;
        this.Url = Url;
    }
    public string Name { get; }
    public string Url { get; }

    public static Result<SocialNetwork> Create(string name, string url)
    {
        if (string.IsNullOrWhiteSpace(name))
            return "Name of social network cannot be empty";
        if (string.IsNullOrWhiteSpace(url))
            return "Url of social network cannot be empty";
        return new SocialNetwork(name, url);
    }
}