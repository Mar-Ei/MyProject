using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int? UserId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? Notes { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual User? User { get; set; }
    }
}
