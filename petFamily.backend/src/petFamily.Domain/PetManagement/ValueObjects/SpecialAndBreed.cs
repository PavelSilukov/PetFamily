using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record SpecialAndBreed
{
    public SpecialAndBreed(SpeciesId speciesId, BreedId breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }

    public SpeciesId SpeciesId { get; }

    public BreedId BreedId { get; } 

    // private static Result<SpecialAndBreed> Create(SpeciesId speciesId, BreedId breedId)
    // {
    //     return new SpecialAndBreed(speciesId, breedId);
    // }
}