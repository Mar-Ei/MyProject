using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Allergy
    {
        public int AllergyId { get; set; }
        public int? UserId { get; set; }
        public string? AllergyName { get; set; }
        public string? Severity { get; set; }

        public virtual User? User { get; set; }
    }
}
