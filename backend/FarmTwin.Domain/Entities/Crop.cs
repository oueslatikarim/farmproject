using System;

namespace FarmTwin.Domain.Entities;

public class Crop
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Variety { get; set; } = string.Empty;
    public int ExpectedGrowingDays { get; set; }
    public double BaseWaterRequirementMmPerDay { get; set; }
}
