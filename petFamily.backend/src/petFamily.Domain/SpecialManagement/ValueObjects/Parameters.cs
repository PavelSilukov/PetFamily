using petFamily.Domain.Shared;

namespace petFamily.Domain.SpecialManagement.ValueObjects;

public record Parameters
{
    private const int MaxWeightKg = 100;
    private const int MinWeightKg = 0;
    private const int MaxHeightCm = 200;
    private const int MinHeightCm = 0;

    private Parameters(int weight, int height, string color)
    {
        Weight = weight;
        Height = height;
        Color = color;
    }
    
    public int Weight  { get; private set; }
    public int Height { get; private set; } 
    public string Color { get; private set; }

    private static Result<Parameters> Create(int weightKg, int heightCm, string color)
    {
        if  (weightKg < MinWeightKg)
            return "Weight kg is too small";
        if(weightKg > MaxWeightKg)
            return "Weight kg is too big";
        if(heightCm < MinHeightCm)
            return "Height cm is too low";
        if(heightCm > MaxHeightCm)
            return "Height cm is too height";
        if(string.IsNullOrEmpty(color))
            return "Color is empty";
        return new Parameters(weightKg, heightCm, color);
    }
    
}