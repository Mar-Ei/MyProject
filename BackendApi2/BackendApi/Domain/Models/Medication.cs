﻿using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Medication
{
    public int MedicationId { get; set; }

    public int UserId { get; set; }

    public string MedicationName { get; set; } = null!;

    public string? Dosage { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual User User { get; set; } = null!;
}
