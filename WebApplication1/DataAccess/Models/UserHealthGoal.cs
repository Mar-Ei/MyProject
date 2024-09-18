using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UserHealthGoal
    {
        public int GoalId { get; set; }
        public int? UserId { get; set; }
        public string? GoalName { get; set; }
        public decimal? TargetValue { get; set; }
        public decimal? CurrentValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual User? User { get; set; }
    }
}
