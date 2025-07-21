using CSharpFunctionalExtensions;
using petFamily.Domain.PetManagement.Enum;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record Requisite
{
    private const int NUMBER_OF_DIGITS_ON_BANK_CARD = 10;
    public string Title { get;}
    public string Description { get;}
    public string CardNumber { get; }
    public PaymentMethod PaymentMethod {get;}
    private Requisite(
        string Title, 
        string Description, 
        string CardNumber, 
        PaymentMethod PaymentMethod)
    {
        this.Title = Title;
        this.Description = Description;
        this.CardNumber = CardNumber;
        this.PaymentMethod = PaymentMethod;
    }
    public static Result<Requisite, Error> Create(
        string title, 
        string description, 
        string cardNumber, 
        PaymentMethod paymentMethod)
    {
        if (string.IsNullOrEmpty(title))
        {
            return Errors.General.ValueIsInvalid("Title");
        }
        if (string.IsNullOrEmpty(description))
        {
            return Errors.General.ValueIsInvalid("Description");
        }

        if (cardNumber.Length != NUMBER_OF_DIGITS_ON_BANK_CARD)
        {
            return Errors.General.ValueIsInvalid("cardNumber");
        }

        return new Requisite(title, description, cardNumber, paymentMethod);
    }
}