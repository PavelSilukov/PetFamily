using System.Reflection.PortableExecutable;
using petFamily.Domain.Shared;

namespace petFamily.Domain.Volunteers;

public record Сharacteristic
{
    const int MaxWeightKG = 100;
    const int MinWeightKG = 0;
    const int MaxHeightCM = 200;
    const int MinHeightCM = 0;

    private Сharacteristic(int weightKg, int heightCm, string color)
    {
        Weight = weightKg;
        Height = heightCm;
        Color = color;
    }
    
    public int Weight  { get; private set; }
    public int Height { get; private set; } 
    public string Color { get; private set; }

    private static Result<Сharacteristic> Create(int weightKg, int heightCm, string color)
    {
        if  (weightKg < MinWeightKG)
            return "Weight kg is too small";
        if(weightKg > MaxWeightKG)
            return "Weight kg is too big";
        if(heightCm < MinHeightCM)
            return "Height cm is too low";
        if(heightCm > MaxHeightCM)
            return "Height cm is too height";
        if(string.IsNullOrEmpty(color))
            return "Color is empty";
        return new Сharacteristic(weightKg, heightCm, color);
    }
    
}