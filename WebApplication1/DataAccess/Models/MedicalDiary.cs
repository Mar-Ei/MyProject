using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class MedicalDiary
    {
        public int DiaryId { get; set; }
        public int? UserId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? Symptoms { get; set; }
        public string? Notes { get; set; }

        public virtual User? User { get; set; }
    }
}
