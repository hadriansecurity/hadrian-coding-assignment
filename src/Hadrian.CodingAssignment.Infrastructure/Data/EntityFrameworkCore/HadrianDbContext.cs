using Hadrian.CodingAssignment.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Hadrian.CodingAssignment.Infrastructure.Data.EntityFrameworkCore;

public class HadrianDbContext : DbContext
{
    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Risk> Risks => Set<Risk>();

    public HadrianDbContext()
    {
    }

    public HadrianDbContext(DbContextOptions<HadrianDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql()
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        // Add some initial data
        var hadrianOrganization = new Organization("Hadrian");
        modelBuilder.Entity<Organization>().HasData(hadrianOrganization);

        var hadrianUser = new User(hadrianOrganization.Id, "Hadrian", "TAC1U1saMwgrjoG2");
        modelBuilder.Entity<User>().HasData(hadrianUser);

        var initialRisks = Enum
            .GetValues<RiskSeverity>()
            .Select(riskSeverity => new Risk(hadrianOrganization.Id, $"{riskSeverity} severity initial risk", riskSeverity, RiskStatus.New))
            .ToArray();
        modelBuilder.Entity<Risk>().HasData(initialRisks);
    }
}