using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int? UserId { get; set; }

    public string? Diagnosis { get; set; }

    public string? Treatment { get; set; }

    public string? DoctorNotes { get; set; }

    public DateOnly? Date { get; set; }

    public virtual User? User { get; set; }
}
