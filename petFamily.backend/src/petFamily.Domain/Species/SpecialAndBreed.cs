using petFamily.Domain.Shared;

namespace petFamily.Domain.Species;

public record SpecialAndBreed
{
    public SpeciesId SpeciesId { get;}
    public BreedId BreedId { get;}

    private SpecialAndBreed(SpeciesId SpeciesId, BreedId BreedId)
    {
       SpeciesId = SpeciesId;
       BreedId = BreedId;
    }

    private static Result<SpecialAndBreed> Create(SpeciesId speciesId, BreedId breedId)
    {
        return new SpecialAndBreed(speciesId, breedId);
    }
}