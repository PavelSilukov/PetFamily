using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using petFamily.Domain.PetManagement.Entities;
using petFamily.Domain.SpecialManagement.Entities;

namespace petFamily.Infrastructure;

public class ApplicationDbContext(IConfiguration configuration):DbContext
{
    private const string DATABASE = "Database";
    public DbSet<Volunteer>Volunteers=>Set<Volunteer>();
    public DbSet<Species>Special=>Set<Species>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString(DATABASE ));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.UseLoggerFactory(CreateLoggerFactory);

    }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
    private ILoggerFactory CreateLoggerFactory =>
    LoggerFactory.Create(builder => {builder.AddConsole();});
    
    


}