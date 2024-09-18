using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class SleepLog
    {
        public int SleepId { get; set; }
        public int? UserId { get; set; }
        public DateTime? SleepDate { get; set; }
        public decimal? HoursSlept { get; set; }
        public string? SleepQuality { get; set; }

        public virtual User? User { get; set; }
    }
}
