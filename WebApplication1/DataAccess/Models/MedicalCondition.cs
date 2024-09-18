using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class MedicalCondition
    {
        public int ConditionId { get; set; }
        public int? UserId { get; set; }
        public string? ConditionName { get; set; }
        public DateTime? DiagnosisDate { get; set; }
        public string? Status { get; set; }

        public virtual User? User { get; set; }
    }
}
