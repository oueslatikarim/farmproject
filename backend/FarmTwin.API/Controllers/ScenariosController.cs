using FarmTwin.Application.Interfaces.Repositories;
using FarmTwin.Application.Models.DTOs;
using FarmTwin.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmTwin.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ScenariosController : ControllerBase
{
    private readonly IScenarioRepository _scenarioRepository;

    public ScenariosController(IScenarioRepository scenarioRepository)
    {
        _scenarioRepository = scenarioRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ScenarioDto>>> GetScenarios()
    {
        var scenarios = await _scenarioRepository.GetAllAsync();
        var dtos = scenarios.Select(s => new ScenarioDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            CreatedAt = s.CreatedAt,
            PlannedIrrigationMm = s.PlannedIrrigationMm,
            PlannedFertilizerKg = s.PlannedFertilizerKg,
            FarmId = s.FarmId,
            CropId = s.CropId
        });
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ScenarioDto>> GetScenario(Guid id)
    {
        var s = await _scenarioRepository.GetByIdAsync(id);

        if (s == null) return NotFound();

        return Ok(new ScenarioDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            CreatedAt = s.CreatedAt,
            PlannedIrrigationMm = s.PlannedIrrigationMm,
            PlannedFertilizerKg = s.PlannedFertilizerKg,
            FarmId = s.FarmId,
            CropId = s.CropId
        });
    }

    [HttpPost]
    public async Task<ActionResult<ScenarioDto>> PostScenario(CreateScenarioDto dto)
    {
        var scenario = new Scenario
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow,
            PlannedIrrigationMm = dto.PlannedIrrigationMm,
            PlannedFertilizerKg = dto.PlannedFertilizerKg,
            FarmId = dto.FarmId,
            CropId = dto.CropId
        };
        
        var created = await _scenarioRepository.AddAsync(scenario);

        var resultDto = new ScenarioDto
        {
            Id = created.Id,
            Name = created.Name,
            Description = created.Description,
            CreatedAt = created.CreatedAt,
            PlannedIrrigationMm = created.PlannedIrrigationMm,
            PlannedFertilizerKg = created.PlannedFertilizerKg,
            FarmId = created.FarmId,
            CropId = created.CropId
        };

        return CreatedAtAction(nameof(GetScenario), new { id = resultDto.Id }, resultDto);
    }
}
