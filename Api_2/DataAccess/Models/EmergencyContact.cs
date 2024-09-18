using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class EmergencyContact
    {
        public int ContactId { get; set; }
        public int? UserId { get; set; }
        public string? ContactName { get; set; }
        public string? Relation { get; set; }
        public string? Phone { get; set; }

        public virtual User? User { get; set; }
    }
}
