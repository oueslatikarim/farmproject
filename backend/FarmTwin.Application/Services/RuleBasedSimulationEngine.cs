using FarmTwin.Application.Interfaces.Services;
using FarmTwin.Application.Models;
using System.Text;

namespace FarmTwin.Application.Services;

public class RuleBasedSimulationEngine : ISimulationEngine
{
    public SimulationResponse Simulate(SimulationRequest request)
    {
        var response = new SimulationResponse
        {
            PredictedYield = request.BaseYieldTons,
            EstimatedCost = request.BaseCost,
            RiskLevel = RiskLevel.Low
        };

        var explanation = new StringBuilder("Simulation applied. ");
        bool highRiskFactor = false;

        // Rule 1: Temperature > 35 and Irrigation < 60%
        if (request.TemperatureCelsius > 35 && request.IrrigationPercentage < 60)
        {
            response.PredictedYield *= 0.85; // Decrease yield by 15%
            highRiskFactor = true;
            explanation.Append("High temperature combined with insufficient irrigation resulted in a 15% yield reduction. ");
        }

        // Rule 2: Fertilizer > optimal threshold
        if (request.FertilizerKg > request.OptimalFertilizerThresholdKg)
        {
            // Determine excess fertilizer and apply cost penalty
            double excessFertilizer = request.FertilizerKg - request.OptimalFertilizerThresholdKg;
            double costPenaltyPerExcessKg = 5.0; // Arbitrary cost coefficient representing price of fertilizer
            
            response.EstimatedCost += (excessFertilizer * costPenaltyPerExcessKg);
            explanation.Append("Fertilizer usage exceeded optimal threshold, adding to final cost without yield improvements. ");
            
            // Re-evaluating risk: Wasting resources could be a medium risk to profitability
            if (!highRiskFactor)
            {
                response.RiskLevel = RiskLevel.Medium;
            }
        }

        if (highRiskFactor)
        {
            response.RiskLevel = RiskLevel.High;
        }

        response.ExplanationText = explanation.ToString().Trim();

        return response;
    }
}
