namespace petFamily.Domain.PetManagement.ValueObjects;

public record SocialNetList
{
    private SocialNetList()
    {
        
    }
    public SocialNetList(IEnumerable<SocialNet> socialNets)
    {
        SocialNetworks = socialNets.ToList();
    }

    public IReadOnlyList<SocialNet> SocialNetworks { get; } = [];
}