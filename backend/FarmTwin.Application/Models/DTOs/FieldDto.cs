using System;
using FarmTwin.Domain.Entities;

namespace FarmTwin.Application.Models.DTOs;

public class FieldDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double AreaHectares { get; set; }
    public SoilType SoilType { get; set; }
    public Guid FarmId { get; set; }
    public Guid? CurrentCropId { get; set; }
}

public class CreateFieldDto
{
    public string Name { get; set; } = string.Empty;
    public double AreaHectares { get; set; }
    public SoilType SoilType { get; set; }
    public Guid FarmId { get; set; }
}
