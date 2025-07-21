using CSharpFunctionalExtensions;
using petFamily.Domain.PetManagement.Entities;
using petFamily.Domain.PetManagement.ValueObjects;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;

namespace petFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _repository;
    public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _repository = volunteersRepository;
    }
    
    public async Task<Result<Guid, Error>> Handle(
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

        var addressResult = Address.Create(
            request.Country, request.City,
            request.Street, 
            request.NumberHouse);
        if (addressResult.IsFailure)
            return addressResult.Error;
        
        var socialNets = new List<SocialNet>();
        var socialNetsResult = request.SocialNets
            .Select((x => SocialNet.Create(x.Name, x.Url)));
        foreach (var sn in socialNetsResult)
        {
            if(sn.IsFailure)
                return sn.Error;
            socialNets.Add(sn.Value);
        }
         
     
        var requisites = new List<Requisite>();
        var requisiteResult = request.Requisites
            .Select((x => Requisite.Create(x.Title, x.Description, x.CardNumber, x.PaymentMethod)));
        foreach (var r in requisiteResult)
        {
            if(r.IsFailure)
                return r.Error;
            requisites.Add(r.Value);
        }
        
        
        var volunteer = new Volunteer(
            volunteerId,
            fullnameResult.Value,
            emailResult.Value,
            phoneNumberResult.Value,
            descriptionResult.Value,
            experinceYearsResult.Value,
            addressResult.Value,
            new SocialNetList(socialNets),
            new RequisiteList(requisites)
        );
        
        await _repository.Add(volunteer, cancellationToken);
        return (Guid)volunteer.Id;
    }
}
    
