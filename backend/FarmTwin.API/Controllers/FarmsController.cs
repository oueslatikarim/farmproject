using FarmTwin.Application.Interfaces.Repositories;
using FarmTwin.Application.Models.DTOs;
using FarmTwin.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmTwin.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // Requires JWT Token
public class FarmsController : ControllerBase
{
    private readonly IFarmRepository _farmRepository;

    public FarmsController(IFarmRepository farmRepository)
    {
        _farmRepository = farmRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FarmDto>>> GetFarms()
    {
        var farms = await _farmRepository.GetAllAsync();
        var dtos = farms.Select(f => new FarmDto
        {
            Id = f.Id,
            Name = f.Name,
            Location = f.Location,
            TotalAreaHectares = f.TotalAreaHectares
        });
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FarmDto>> GetFarm(Guid id)
    {
        var farm = await _farmRepository.GetByIdAsync(id);

        if (farm == null)
            return NotFound();

        var dto = new FarmDto
        {
            Id = farm.Id,
            Name = farm.Name,
            Location = farm.Location,
            TotalAreaHectares = farm.TotalAreaHectares
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<FarmDto>> PostFarm(CreateFarmDto createDto)
    {
        var farm = new Farm
        {
            Id = Guid.NewGuid(),
            Name = createDto.Name,
            Location = createDto.Location,
            TotalAreaHectares = createDto.TotalAreaHectares,
            OwnerId = "TempOwnerId" // Would come from JWT Claims
        };
        
        var createdFarm = await _farmRepository.AddAsync(farm);

        var dto = new FarmDto
        {
            Id = createdFarm.Id,
            Name = createdFarm.Name,
            Location = createdFarm.Location,
            TotalAreaHectares = createdFarm.TotalAreaHectares
        };

        return CreatedAtAction(nameof(GetFarm), new { id = dto.Id }, dto);
    }
}
