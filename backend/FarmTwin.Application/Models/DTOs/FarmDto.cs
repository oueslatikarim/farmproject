using System;

namespace FarmTwin.Application.Models.DTOs;

public class FarmDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double TotalAreaHectares { get; set; }
}

public class CreateFarmDto
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double TotalAreaHectares { get; set; }
}
