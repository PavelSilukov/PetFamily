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
        CreateVolunteerCommand request,
        CancellationToken cancellationToken = default
    )
    {
        var fullname = FullName.Create(
            request.FirstName, 
            request.Surname, 
            request.SecondName).Value;

        var email = Email.Create(request.Email).Value;


        var phoneNumber = PhoneNumber.Create(request.PhoneNumber).Value;


        var description = Description.Create(request.Description).Value;
        

        var experinceYears = ExperienceYears.Create(request.ExperienceYears).Value;


        var addressResult = Address.Create(
            request.Country, request.City,
            request.Street,
            request.NumberHouse).Value;
        
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
        
        var volunteerByPhone = await _repository.GetByPhone(
            phoneNumber,
            cancellationToken);
        if (volunteerByPhone.IsSuccess)
        {
            return Errors.Volunteer.AlredyExist();
        }
        
        var volunteerId = VolunteerId.Create(Guid.NewGuid());
        
        var volunteer = new Volunteer(
            volunteerId,
            fullname,
            email,
            phoneNumber,
            description,
            experinceYears,
            addressResult,
            new SocialNetList(socialNets),
            new RequisiteList(requisites)
        );
        
        await _repository.Add(volunteer, cancellationToken);
        return (Guid)volunteer.Id;
    }
}
    
