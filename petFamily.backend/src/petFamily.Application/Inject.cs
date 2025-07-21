using Microsoft.Extensions.DependencyInjection;
using petFamily.Application.Volunteers.CreateVolunteer;

namespace petFamily.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateVolunteerHandler>();
        return services;
    }
}