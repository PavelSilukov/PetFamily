using Microsoft.EntityFrameworkCore;
using petFamily.Application.Volunteers;
using petFamily.Domain.PetManagement.Entities;
using petFamily.Domain.Shared;
using petFamily.Domain.Shared.IDs;
namespace petFamily.Infrastructure.Repositories;

public class VolunteersRepository : IVolunteersRepository
{
    private readonly ApplicationDbContext _context;

    public VolunteersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await _context.Volunteers.AddAsync(volunteer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return volunteer.Id;
    }

    public async Task<Result<Volunteer>> GetById(VolunteerId volunteerId)
    {
        var volunteer = await _context.Volunteers
            .Include(v=>v.pets)
            .FirstOrDefaultAsync((v=>v.Id.Value == volunteerId));
        if (volunteer is null)
            return "Volunteer not found";
        return volunteer;
    }
    
    
}