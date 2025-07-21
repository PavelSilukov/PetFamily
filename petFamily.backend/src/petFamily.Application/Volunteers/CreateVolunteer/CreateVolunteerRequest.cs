using petFamily.Application.Dtos;
using petFamily.Domain.PetManagement.Enum;

namespace petFamily.Application.Volunteers.CreateVolunteer;

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
    IEnumerable<SocialNetsDto>  SocialNets,
    IEnumerable<RequisiteDto>  Requisites
    
    );