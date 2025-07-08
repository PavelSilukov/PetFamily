using CSharpFunctionalExtensions;
using petFamily.Domain.PetManagement.Entities;
using petFamily.Domain.PetManagement.ValueObjects;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;

namespace petFamily.Application.Voluntreers.CreateVolunteer;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _repository;
    public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _repository = volunteersRepository;
    }
    
    public async Task<Result<Guid, string>> Handle(
        CreateVolunteerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var volunteerId = VolunteerId.Create(Guid.NewGuid());

        var fullnameResult = FullName.Create(
            request.FirstName,
            request.Surname,
            request.SecondName);
        if (fullnameResult.IsFailure)
            return fullnameResult.Error;

        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure)
            return emailResult.Error;

        var phoneNumberResult = PhoneNumber.Create(request.PhoneNumber);
        if (phoneNumberResult.IsFailure)
            return phoneNumberResult.Error;

        var descriptionResult = Description.Create(request.Description);
        if (descriptionResult.IsFailure)
            return descriptionResult.Error;

        var experinceYearsResult = ExperienceYears.Create(request.ExperienceYears);
        if (experinceYearsResult.IsFailure)
            return experinceYearsResult.Error;

        var addressResult = Address.Create(request.Country, request.City, request.Street, request.NumberHouse);
        if (addressResult.IsFailure)
            return addressResult.Error;

        var requisiteResult = Requisite.Create(
            request.TitleRequesite,
            request.DescriptionRequesite,
            request.CardNumber,
            request.PaymentMethod);
        if (requisiteResult.IsFailure)
            return requisiteResult.Error;

        var socialNetworkResult = SocialNetwork.Create(request.NameSocialNet, request.UrlSocialNet);
        if (socialNetworkResult.IsFailure)
            return socialNetworkResult.Error;

        var volanteerSocial = new VolunteerSocialNets();
        volanteerSocial.SocialNetworks.Add(socialNetworkResult.Value);


        if (socialNetworkResult.IsFailure)
            return socialNetworkResult.Error;

        var volunteer = new Volunteer(
            volunteerId,
            fullnameResult.Value,
            emailResult.Value,
            phoneNumberResult.Value,
            descriptionResult.Value,
            experinceYearsResult.Value,
            addressResult.Value,
            requisiteResult.Value,
            volanteerSocial
        );
        
        await _repository.Add(volunteer, cancellationToken);
        return volunteer.Id.Value;
    }
}
    
