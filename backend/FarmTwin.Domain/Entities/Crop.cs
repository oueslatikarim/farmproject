using System;

using FarmTwin.Domain.Common;

namespace FarmTwin.Domain.Entities;

public class Crop : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Variety { get; set; } = string.Empty;
    public int ExpectedGrowingDays { get; set; }
    public double BaseWaterRequirementMmPerDay { get; set; }
}
