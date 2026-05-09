using System;

namespace FarmTwin.Domain.Entities;

public class WeatherRecord
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public double TemperatureCelsius { get; set; }
    public double RainfallMm { get; set; }
    public double HumidityPercentage { get; set; }
    
    // Foreign Key
    public Guid FieldId { get; set; }
    public Field Field { get; set; } = null!;
}
