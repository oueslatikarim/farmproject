using System;
using System.Collections.Generic;

namespace FarmTwin.Domain.Entities;

public class Farm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty; // From JWT
    public string Location { get; set; } = string.Empty;
    public double TotalAreaHectares { get; set; }
    
    // Navigation property
    public ICollection<Field> Fields { get; set; } = new List<Field>();
    public ICollection<Scenario> Scenarios { get; set; } = new List<Scenario>();
}
