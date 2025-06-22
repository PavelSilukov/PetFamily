using petFamily.Domain.Shared;
using petFamily.Domain.Species;

namespace petFamily.Domain.Volunteers;

public record SpecialAndBreed
{
    public SpeciesId SpeciesId { get;}
    public BreedId BreedId { get;}

    private SpecialAndBreed(SpeciesId speciesId, BreedId breedId)
    {
     
        SpeciesId = speciesId;
       BreedId = breedId;
    }

    private static Result<SpecialAndBreed> Create(SpeciesId speciesId, BreedId breedId)
    {
        return new SpecialAndBreed(speciesId, breedId);
    }
}