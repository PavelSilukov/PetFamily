namespace petFamily.Domain.Shared;

public record Description
{
    private const int MaxLength = 200;
    private Description(string Desc)
    {
        this.Desc = Desc;
    }
    //Окрас
    public string Desc { get;}
    //

    public static Result<Description> Create(string description)
    {
        if(string.IsNullOrWhiteSpace(description)||description.Length > MaxLength)
            return "NickName cannot be null or empty";
        return new Description(description);
    }
}