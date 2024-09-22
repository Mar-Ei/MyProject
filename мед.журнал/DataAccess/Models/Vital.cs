using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Vital
{
    public int VitalId { get; set; }

    public int? UserId { get; set; }

    public int? HeartRate { get; set; }

    public string? BloodPressure { get; set; }

    public decimal? BodyTemperature { get; set; }

    public DateOnly Date { get; set; }

    public virtual User? User { get; set; }
}
