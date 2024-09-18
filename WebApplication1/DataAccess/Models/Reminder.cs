using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Reminder
    {
        public int ReminderId { get; set; }
        public int? UserId { get; set; }
        public string? ReminderText { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool? IsCompleted { get; set; }

        public virtual User? User { get; set; }
    }
}
