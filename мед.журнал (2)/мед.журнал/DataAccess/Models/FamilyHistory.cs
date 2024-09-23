using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class FamilyHistory
{
    public int HistoryId { get; set; }

    public int? UserId { get; set; }

    public string RelativeName { get; set; } = null!;

    public string Condition { get; set; } = null!;

    public int? AgeDiagnosed { get; set; }

    public virtual User? User { get; set; }
}
