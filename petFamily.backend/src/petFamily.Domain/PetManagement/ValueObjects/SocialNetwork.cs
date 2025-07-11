using CSharpFunctionalExtensions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record SocialNetwork
{
    private SocialNetwork(string name, string url)
    {
        Name = name;
        Url = url;
    }
    public string Name { get; }
    public string Url { get; }

    public static Result<SocialNetwork, Error> Create(string name, string url)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("Name of Social Network");
        if (string.IsNullOrWhiteSpace(url))
            return Errors.General.ValueIsInvalid("Url of Social Network");
        return new SocialNetwork(name, url);
    }
}