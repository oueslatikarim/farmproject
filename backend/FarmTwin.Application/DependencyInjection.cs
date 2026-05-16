using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FarmTwin.Application.Interfaces.Auth;
using FarmTwin.Application.Services;

namespace FarmTwin.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Add Application layer services (AutoMapper, MediatR, FluentValidation, etc.) here
        // For now, we only register the Simulation Engine
        services.AddScoped<FarmTwin.Application.Interfaces.Services.ISimulationEngine, FarmTwin.Application.Services.RuleBasedSimulationEngine>();
        
        services.AddValidatorsFromAssemblyContaining<Validators.LoginRequestValidator>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
