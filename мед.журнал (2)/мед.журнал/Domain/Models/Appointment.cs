using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? UserId { get; set; }

    public string DoctorName { get; set; } = null!;

    public DateOnly AppointmentDate { get; set; }

    public string? Reason { get; set; }

    public string? Clinic { get; set; }

    public virtual User? User { get; set; }
}
