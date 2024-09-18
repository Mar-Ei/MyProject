using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Vaccination
    {
        public int VaccinationId { get; set; }
        public int? UserId { get; set; }
        public string? VaccineName { get; set; }
        public DateTime? DateGiven { get; set; }
        public DateTime? BoosterDue { get; set; }

        public virtual User? User { get; set; }
    }
}
