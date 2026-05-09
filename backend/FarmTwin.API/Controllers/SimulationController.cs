using FarmTwin.Application.Interfaces.Services;
using FarmTwin.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmTwin.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SimulationController : ControllerBase
{
    private readonly ISimulationEngine _simulationEngine;

    public SimulationController(ISimulationEngine simulationEngine)
    {
        _simulationEngine = simulationEngine;
    }

    [HttpPost("run")]
    public ActionResult<SimulationResponse> RunSimulation([FromBody] SimulationRequest request)
    {
        if (request == null)
            return BadRequest();

        var response = _simulationEngine.Simulate(request);

        return Ok(response);
    }
}
