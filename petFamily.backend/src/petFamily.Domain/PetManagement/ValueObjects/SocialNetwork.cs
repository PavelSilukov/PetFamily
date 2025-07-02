using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record SocialNetwork
{
    private SocialNetwork(string name, string url)
    {
        this.Name = name;
        this.Url = url;
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