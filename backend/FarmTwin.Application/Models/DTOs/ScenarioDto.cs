using System;

namespace FarmTwin.Application.Models.DTOs;

public class ScenarioDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public double PlannedIrrigationMm { get; set; }
    public double PlannedFertilizerKg { get; set; }
    public Guid FarmId { get; set; }
    public Guid CropId { get; set; }
}

public class CreateScenarioDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double PlannedIrrigationMm { get; set; }
    public double PlannedFertilizerKg { get; set; }
    public Guid FarmId { get; set; }
    public Guid CropId { get; set; }
}
