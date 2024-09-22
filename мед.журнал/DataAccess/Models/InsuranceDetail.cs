using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class InsuranceDetail
{
    public int InsuranceId { get; set; }

    public int? UserId { get; set; }

    public string InsuranceCompany { get; set; } = null!;

    public string PolicyNumber { get; set; } = null!;

    public string? CoverageDetails { get; set; }

    public virtual User? User { get; set; }
}
