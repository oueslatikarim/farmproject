using FarmTwin.Application.Interfaces.Repositories;
using FarmTwin.Application.Models.DTOs;
using FarmTwin.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmTwin.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FieldsController : ControllerBase
{
    private readonly IFieldRepository _fieldRepository;

    public FieldsController(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FieldDto>>> GetFields()
    {
        var fields = await _fieldRepository.GetAllAsync();
        var dtos = fields.Select(f => new FieldDto
        {
            Id = f.Id,
            Name = f.Name,
            AreaHectares = f.AreaHectares,
            SoilType = f.SoilType,
            FarmId = f.FarmId,
            CurrentCropId = f.CurrentCropId
        });
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FieldDto>> GetField(Guid id)
    {
        var f = await _fieldRepository.GetByIdAsync(id);

        if (f == null) return NotFound();

        return Ok(new FieldDto
        {
            Id = f.Id,
            Name = f.Name,
            AreaHectares = f.AreaHectares,
            SoilType = f.SoilType,
            FarmId = f.FarmId,
            CurrentCropId = f.CurrentCropId
        });
    }

    [HttpPost]
    public async Task<ActionResult<FieldDto>> PostField(CreateFieldDto dto)
    {
        var field = new Field
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            AreaHectares = dto.AreaHectares,
            SoilType = dto.SoilType,
            FarmId = dto.FarmId
        };
        
        var created = await _fieldRepository.AddAsync(field);

        var resultDto = new FieldDto
        {
            Id = created.Id,
            Name = created.Name,
            AreaHectares = created.AreaHectares,
            SoilType = created.SoilType,
            FarmId = created.FarmId
        };

        return CreatedAtAction(nameof(GetField), new { id = resultDto.Id }, resultDto);
    }
}
