using CSharpFunctionalExtensions;

namespace petFamily.Domain.Shared;

public record Description
{
    private Description(string Desc)
    {
        this.Desc = Desc;
    }
    //Окрас
    public string Desc { get;}
    //

    public static Result<Description, Error> Create(string description)
    {
        if(string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid("Description");
        return new Description(description);
    }
}