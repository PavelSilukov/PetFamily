using petFamily.API.Validation;
using petFamily.Application;
using petFamily.Infrastructure;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace petFamily.API;

public static class Inject
{
    public static IServiceCollection AddAPI (this IServiceCollection services)
    {
        services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}