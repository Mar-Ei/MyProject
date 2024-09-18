using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UserDoctorRelation
    {
        public int RelationId { get; set; }
        public int? UserId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? LastVisited { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual User? User { get; set; }
    }
}
