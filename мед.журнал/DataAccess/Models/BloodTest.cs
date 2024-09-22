using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class BloodTest
{
    public int BloodTestId { get; set; }

    public int? UserId { get; set; }

    public decimal? Hemoglobin { get; set; }

    public decimal? WhiteBloodCells { get; set; }

    public decimal? Cholesterol { get; set; }

    public decimal? BloodGlucose { get; set; }

    public DateOnly TestDate { get; set; }

    public virtual User? User { get; set; }
}
