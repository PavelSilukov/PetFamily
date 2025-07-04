﻿using petFamily.Domain.Shared;

namespace petFamily.Domain.SpecialManagement.ValueObjects;

public record NameOfBreed
{
    private NameOfBreed(string name )
    {
        Name = name ;
    }
    //Окрас
    public string Name { get;}
    //

    private static Result<NameOfBreed> Create(string nameOfBreed)
    {
        if(string.IsNullOrWhiteSpace(nameOfBreed))
            return "NickName cannot be null or empty";
        return new NameOfBreed(nameOfBreed);
    }
}