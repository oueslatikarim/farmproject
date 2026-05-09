using FarmTwin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FarmTwin.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Farm> Farms => Set<Farm>();
    public DbSet<Field> Fields => Set<Field>();
    public DbSet<Crop> Crops => Set<Crop>();
    public DbSet<Scenario> Scenarios => Set<Scenario>();
    public DbSet<SimulationResult> SimulationResults => Set<SimulationResult>();
    public DbSet<WeatherRecord> WeatherRecords => Set<WeatherRecord>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Apply configurations from assembly if any
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Basic configurations
        builder.Entity<Field>()
            .HasOne(f => f.Farm)
            .WithMany(f => f.Fields)
            .HasForeignKey(f => f.FarmId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<WeatherRecord>()
            .HasOne(w => w.Field)
            .WithMany(f => f.WeatherRecords)
            .HasForeignKey(w => w.FieldId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Scenario>()
            .HasOne(s => s.Farm)
            .WithMany(f => f.Scenarios)
            .HasForeignKey(s => s.FarmId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<SimulationResult>()
            .HasOne(r => r.Scenario)
            .WithMany(s => s.Results)
            .HasForeignKey(r => r.ScenarioId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.Entity<Field>()
            .HasOne(f => f.CurrentCrop)
            .WithMany()
            .HasForeignKey(f => f.CurrentCropId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
