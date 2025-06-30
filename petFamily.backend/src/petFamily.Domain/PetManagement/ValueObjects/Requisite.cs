using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record Requisite
{
    private Requisite(string Title, string Description)
    {
        this.Title = Title;
        this.Description = Description;
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