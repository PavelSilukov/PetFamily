﻿using petFamily.Domain.Shared;

namespace petFamily.Domain.SpecialManagement.ValueObjects;

public record ExternalSigns
{
    private ExternalSigns(string? specialFeatures)
    {
        SpecialFeatures = specialFeatures;
    }
    public string? SpecialFeatures { get; }

    private static Result<ExternalSigns> Create(string? specialFeatures)
    {
        return new ExternalSigns(specialFeatures);
    }
}