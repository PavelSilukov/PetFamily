using petFamily.Domain.PetManagement.Enum;

namespace petFamily.Application.Voluntreers.CreateVolunteer;

public record CreateVolunteerRequest(
    string FirstName,
    string Surname,
    string SecondName,
    string Email,
    string PhoneNumber,
    string Description,
    int ExperienceYears,
    string Country,
    string City,
    string Street,
    int NumberHouse,
    string TitleRequesite,
    string DescriptionRequesite,
    int CardNumber,
    PaymentMethod PaymentMethod,
    string NameSocialNet,
    string UrlSocialNet
    );