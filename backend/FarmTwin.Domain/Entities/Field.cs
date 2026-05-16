using System;
using System.Collections.Generic;
using FarmTwin.Domain.Common;

namespace FarmTwin.Domain.Entities;

public class Field : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public double AreaHectares { get; set; }
    public SoilType SoilType { get; set; }

    // Foreign Key
    public Guid FarmId { get; set; }
    public Farm Farm { get; set; } = null!;

    // Current/Active Crop
    public Guid? CurrentCropId { get; set; }
    public Crop? CurrentCrop { get; set; }
    
    public ICollection<WeatherRecord> WeatherRecords { get; set; } = new List<WeatherRecord>();
}
