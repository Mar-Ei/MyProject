using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class UserProfile
{
    public int UserProfileId { get; set; }

    public int? UserId { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }

    public string? BloodType { get; set; }

    public string? Allergies { get; set; }

    public string? ChronicConditions { get; set; }

    public virtual User? User { get; set; }
}
