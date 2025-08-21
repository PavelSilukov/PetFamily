using CSharpFunctionalExtensions;
using petFamily.Domain.PetManagement.Entities;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;

namespace petFamily.Application.Volunteers;

public interface IVolunteersRepository
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default);
    Task<Result<Volunteer, Error>> GetById(VolunteerId volunteerId);
    Task<Result<Volunteer,Error>> GetByPhone(PhoneNumber phoneNumber, CancellationToken cancellationToken);
}