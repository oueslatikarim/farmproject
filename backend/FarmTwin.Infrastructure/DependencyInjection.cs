using FarmTwin.Application.Interfaces.Repositories;
using FarmTwin.Infrastructure.Data;
using FarmTwin.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FarmTwin.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString,
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IFarmRepository, FarmRepository>();
        services.AddScoped<IFieldRepository, FieldRepository>();
        services.AddScoped<IScenarioRepository, ScenarioRepository>();

        return services;
    }
}
