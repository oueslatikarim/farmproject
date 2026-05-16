using FarmTwin.Application.Interfaces.Repositories;
using FarmTwin.Infrastructure.Data;
using FarmTwin.Infrastructure.Repositories;
using FarmTwin.Application.Interfaces;
using FarmTwin.Application.Interfaces.Auth;
using FarmTwin.Infrastructure.Auth;
using FarmTwin.Infrastructure.Services;
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

        // Auth
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}
