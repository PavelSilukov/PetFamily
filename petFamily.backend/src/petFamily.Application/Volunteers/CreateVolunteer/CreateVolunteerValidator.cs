using FluentValidation;
using petFamily.Application.Validation;
using petFamily.Domain.PetManagement.ValueObjects;
using petFamily.Domain.Shared;

namespace petFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerValidator:AbstractValidator<CreateVolunteerRequest>
{
    public CreateVolunteerValidator()
    {
        RuleFor(fn => new
        {
            fn.FirstName,
            fn.Surname,
            fn.SecondName
        }).MustBeValueObject(f =>
            FullName.Create(f.FirstName, f.Surname, f.SecondName));
        
        RuleFor(e => e.Email).MustBeValueObject(Email.Create);
        RuleFor(p => p.PhoneNumber).MustBeValueObject(PhoneNumber.Create);
        RuleFor(c => c.Description).MustBeValueObject(Description.Create);
        RuleFor(e => e.ExperienceYears).MustBeValueObject(ExperienceYears.Create);
        
        RuleFor(ad => new
        {
            ad.Country,
            ad.City,
            ad.Street,
            ad.NumberHouse
        }).MustBeValueObject(a =>
            Address.Create(a.Country, a.City, a.Street, a.NumberHouse));

        RuleForEach(snl => snl.SocialNets).ChildRules(sn =>
        {
            sn.RuleFor(s => new
            {
                s.Name,
                s.Url
            }).MustBeValueObject(so => SocialNet.Create(so.Name, so.Url));
        });
        
        RuleForEach(req => req.Requisites).ChildRules(re =>
        {
            re.RuleFor(r => new
            {
                r.Title,
                r.Description,
                r.CardNumber,
                r.PaymentMethod
            }).MustBeValueObject(ro => 
                Requisite.Create(ro.Title, ro.Description, ro.CardNumber, ro.PaymentMethod));
        });
    }
}