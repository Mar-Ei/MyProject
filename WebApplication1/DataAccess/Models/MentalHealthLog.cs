using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class MentalHealthLog
    {
        public int LogId { get; set; }
        public int? UserId { get; set; }
        public DateTime? LogDate { get; set; }
        public string? Mood { get; set; }
        public int? StressLevel { get; set; }

        public virtual User? User { get; set; }
    }
}
