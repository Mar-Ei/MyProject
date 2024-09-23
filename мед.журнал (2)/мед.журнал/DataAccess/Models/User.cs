using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<BloodTest> BloodTests { get; set; } = new List<BloodTest>();

    public virtual ICollection<ExerciseTracking> ExerciseTrackings { get; set; } = new List<ExerciseTracking>();

    public virtual ICollection<FamilyHistory> FamilyHistories { get; set; } = new List<FamilyHistory>();

    public virtual ICollection<Immunization> Immunizations { get; set; } = new List<Immunization>();

    public virtual ICollection<InsuranceDetail> InsuranceDetails { get; set; } = new List<InsuranceDetail>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual ICollection<Medication1> Medication1s { get; set; } = new List<Medication1>();

    public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();

    public virtual ICollection<NutritionTracking> NutritionTrackings { get; set; } = new List<NutritionTracking>();

    public virtual ICollection<SleepTracking> SleepTrackings { get; set; } = new List<SleepTracking>();

    public virtual ICollection<SymptomsTracking> SymptomsTrackings { get; set; } = new List<SymptomsTracking>();

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

    public virtual ICollection<Vital> Vitals { get; set; } = new List<Vital>();
}
