using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            UserDoctorRelations = new HashSet<UserDoctorRelation>();
        }

        public int DoctorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Specialization { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<UserDoctorRelation> UserDoctorRelations { get; set; }
    }
}
