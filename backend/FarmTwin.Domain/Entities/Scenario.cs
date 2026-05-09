using System;
using System.Collections.Generic;

namespace FarmTwin.Domain.Entities;

public class Scenario
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Parameters for simulation
    public double PlannedIrrigationMm { get; set; }
    public double PlannedFertilizerKg { get; set; }
    
    // Foreign Keys
    public Guid FarmId { get; set; }
    public Farm Farm { get; set; } = null!;

    public Guid CropId { get; set; }
    public Crop Crop { get; set; } = null!;

    public ICollection<SimulationResult> Results { get; set; } = new List<SimulationResult>();
}
