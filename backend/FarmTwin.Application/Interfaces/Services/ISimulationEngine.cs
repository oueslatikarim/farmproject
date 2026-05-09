using FarmTwin.Application.Models;

namespace FarmTwin.Application.Interfaces.Services;

public interface ISimulationEngine
{
    SimulationResponse Simulate(SimulationRequest request);
}
