using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ExerciseTracking
{
    public int ExerciseId { get; set; }

    public int? UserId { get; set; }

    public string ActivityType { get; set; } = null!;

    public int DurationMinutes { get; set; }

    public decimal? CaloriesBurned { get; set; }

    public DateOnly Date { get; set; }

    public virtual User? User { get; set; }
}
