using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using petFamily.API;
using petFamily.API.Validation;
using petFamily.Application;
using petFamily.Application.Volunteers;
using petFamily.Application.Volunteers.CreateVolunteer;
using petFamily.Infrastructure;
using petFamily.Infrastructure.Repositories;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services
    .AddInfrastructure()
    .AddApplication()
    .AddAPI();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


