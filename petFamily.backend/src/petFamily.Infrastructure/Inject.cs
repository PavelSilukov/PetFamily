using Microsoft.Extensions.DependencyInjection;
using petFamily.Application.Volunteers;
using petFamily.Infrastructure.Repositories;

namespace petFamily.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext>();
        services.AddScoped<IVolunteersRepository, VolunteersRepository>();
        return services;
        
    }
}