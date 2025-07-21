using petFamily.Domain.PetManagement.Enum;

namespace petFamily.Application.Dtos;

public record RequisiteDto(
    string Title, 
    string Description, 
    string CardNumber, 
    PaymentMethod PaymentMethod);