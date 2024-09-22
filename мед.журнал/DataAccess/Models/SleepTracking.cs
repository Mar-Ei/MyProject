using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class SleepTracking
{
    public int SleepId { get; set; }

    public int? UserId { get; set; }

    public decimal SleepDuration { get; set; }

    public int? SleepQuality { get; set; }

    public int? WakeUpTimes { get; set; }

    public DateOnly Date { get; set; }

    public virtual User? User { get; set; }
}
