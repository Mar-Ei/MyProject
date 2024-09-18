﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class PhysicalActivity
    {
        public int ActivityId { get; set; }
        public int? UserId { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string? ActivityType { get; set; }
        public int? DurationMinutes { get; set; }
        public int? CaloriesBurned { get; set; }

        public virtual User? User { get; set; }
    }
}