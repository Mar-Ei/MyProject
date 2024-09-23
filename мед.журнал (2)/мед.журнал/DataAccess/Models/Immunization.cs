using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Immunization
{
    public int ImmunizationId { get; set; }

    public int? UserId { get; set; }

    public string VaccineName { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual User? User { get; set; }
}
