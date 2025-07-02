using petFamily.Domain.PetManagement.Enum;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record Requisite
{
    private const int NUMBER_OF_DIGITS_ON_BANK_CARD = 10;
    public string Title { get;}
    public string Description { get;}
    public int CardNumber { get; }
    public PaymentMethod PaymentMethod {get;}
    private Requisite(string Title, string Description, int CardNumber, PaymentMethod PaymentMethod)
    {
        this.Title = Title;
        this.Description = Description;
        this.CardNumber = CardNumber;
        this.PaymentMethod = PaymentMethod;
    }
    public static Result<Requisite> Create(string title, string description, int cardNumber, PaymentMethod paymentMethod)
    {
        if (string.IsNullOrEmpty(title))
        {
            return "Title is not null or empty";
        }
        if (string.IsNullOrEmpty(description))
        {
            return "Description is not null or empty";
        }

        if (cardNumber != NUMBER_OF_DIGITS_ON_BANK_CARD)
        {
            return "Invalid card number";
        }
        return new Requisite(title, description, cardNumber, paymentMethod);
    }
}