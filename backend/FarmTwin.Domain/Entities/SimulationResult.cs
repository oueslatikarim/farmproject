using System;

using FarmTwin.Domain.Common;

namespace FarmTwin.Domain.Entities;

public class SimulationResult : BaseEntity
{
    public DateTime SimulatedDate { get; set; }
    public double PredictedYieldTons { get; set; }
    public double PredictedWaterUsageMm { get; set; }
    public double EstimatedCost { get; set; }
    public double EstimatedRevenue { get; set; }
    
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

    public Guid ScenarioId { get; set; }
    public Scenario Scenario { get; set; } = null!;
}
