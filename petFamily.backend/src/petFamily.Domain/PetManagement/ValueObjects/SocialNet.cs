using CSharpFunctionalExtensions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record SocialNet
{
    private SocialNet(string name, string url)
    {
        Name = name;
        Url = url;
    }
    public string Name { get; }
    public string Url { get; }

    public static Result<SocialNet, Error> Create(string name, string url)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("Network");
        if (string.IsNullOrWhiteSpace(url))
            return Errors.General.ValueIsInvalid("Url");
        return new SocialNet(name, url);
    }
    
}