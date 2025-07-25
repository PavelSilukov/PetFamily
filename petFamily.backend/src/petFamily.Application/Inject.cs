using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using petFamily.Application.Validation;
using petFamily.Application.Volunteers.CreateVolunteer;

namespace petFamily.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateVolunteerHandler>();
        services.AddValidatorsFromAssemblies([typeof(Inject).Assembly]);
        
        return services;
    }
}