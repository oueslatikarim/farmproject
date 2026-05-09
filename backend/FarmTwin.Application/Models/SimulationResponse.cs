namespace FarmTwin.Application.Models;

public enum RiskLevel
{
    Low,
    Medium,
    High
}

public class SimulationResponse
{
    public double PredictedYield { get; set; }
    public RiskLevel RiskLevel { get; set; }
    public double EstimatedCost { get; set; }
    public string ExplanationText { get; set; } = string.Empty;
}
