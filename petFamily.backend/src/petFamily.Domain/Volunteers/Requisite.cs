using petFamily.Domain.Shared;

namespace petFamily.Domain.Volunteers;

public record Requisite
{
    private Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }
    public string Title { get; }
    public string Description { get;}

    public static Result<Requisite> Create(string title, string description)
    {
        if (string.IsNullOrEmpty(title))
        {
            return "Title is not null or empty";
        }
        if (string.IsNullOrEmpty(description))
        {
            return "Description is not null or empty";
        }
        return new Requisite(title, description);
    }
}