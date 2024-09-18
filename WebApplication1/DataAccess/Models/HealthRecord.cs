using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class HealthRecord
    {
        public int RecordId { get; set; }
        public int? UserId { get; set; }
        public DateTime? RecordDate { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string? BloodPressure { get; set; }
        public int? HeartRate { get; set; }
        public decimal? CholesterolLevel { get; set; }

        public virtual User? User { get; set; }
    }
}
