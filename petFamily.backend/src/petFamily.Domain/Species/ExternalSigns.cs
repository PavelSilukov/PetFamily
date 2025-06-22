using petFamily.Domain.Shared;

namespace petFamily.Domain.Species;

public record ExternalSigns
{
    private ExternalSigns(string color, string specialFeatures)
    {
        Color = color;
        SpecialFeatures = specialFeatures;
    }
    //Окрас
    public string Color { get;}
    //
    public string? SpecialFeatures { get; }

    private static Result<ExternalSigns> Create(string color, string specialFeatures)
    {
        if(string.IsNullOrEmpty(color))
            return "Color cannot be null or empty";
        return new ExternalSigns(color, specialFeatures);
    }
}