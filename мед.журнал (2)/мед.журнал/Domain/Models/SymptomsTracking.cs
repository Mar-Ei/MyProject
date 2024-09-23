using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class SymptomsTracking
{
    public int SymptomId { get; set; }

    public int? UserId { get; set; }

    public string SymptomDescription { get; set; } = null!;

    public int? Severity { get; set; }

    public DateOnly Date { get; set; }

    public virtual User? User { get; set; }
}
