using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class TestsResult
    {
        public int TestResultId { get; set; }
        public int? UserId { get; set; }
        public int? TestTypeId { get; set; }
        public DateTime? TestDate { get; set; }
        public string? Result { get; set; }

        public virtual TestType? TestType { get; set; }
        public virtual User? User { get; set; }
    }
}
