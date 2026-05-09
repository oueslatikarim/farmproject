namespace FarmTwin.Application.Models;

public class SimulationRequest
{
    public double TemperatureCelsius { get; set; }
    public double IrrigationPercentage { get; set; } // 0 - 100
    public double FertilizerKg { get; set; }
    public double OptimalFertilizerThresholdKg { get; set; }
    public double BaseYieldTons { get; set; }
    public double BaseCost { get; set; }
}
