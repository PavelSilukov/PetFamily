using Microsoft.EntityFrameworkCore;
using petFamily.Infrastructure;

namespace petFamily.API;

public static class AppExtentions
{
    public static async Task ApplyMigrations(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
    
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}