using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class MedicalContext : DbContext
{
    public MedicalContext()
    {
    }

    public MedicalContext(DbContextOptions<MedicalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<BloodTest> BloodTests { get; set; }

    public virtual DbSet<ExerciseTracking> ExerciseTrackings { get; set; }

    public virtual DbSet<FamilyHistory> FamilyHistories { get; set; }

    public virtual DbSet<Immunization> Immunizations { get; set; }

    public virtual DbSet<InsuranceDetail> InsuranceDetails { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Medication1> Medications1 { get; set; }

    public virtual DbSet<NutritionTracking> NutritionTrackings { get; set; }

    public virtual DbSet<SleepTracking> SleepTrackings { get; set; }

    public virtual DbSet<SymptomsTracking> SymptomsTrackings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<Vital> Vitals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__A50828FC5F06AA2E");

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("appointment_id");
            entity.Property(e => e.AppointmentDate).HasColumnName("appointment_date");
            entity.Property(e => e.Clinic)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clinic");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("doctor_name");
            entity.Property(e => e.Reason)
                .HasColumnType("text")
                .HasColumnName("reason");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Appointme__user___38996AB5");
        });

        modelBuilder.Entity<BloodTest>(entity =>
        {
            entity.HasKey(e => e.BloodTestId).HasName("PK__Blood_Te__E2C0B0CC6E406A15");

            entity.ToTable("Blood_Tests");

            entity.Property(e => e.BloodTestId)
                .ValueGeneratedNever()
                .HasColumnName("blood_test_id");
            entity.Property(e => e.BloodGlucose)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("blood_glucose");
            entity.Property(e => e.Cholesterol)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("cholesterol");
            entity.Property(e => e.Hemoglobin)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("hemoglobin");
            entity.Property(e => e.TestDate).HasColumnName("test_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WhiteBloodCells)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("white_blood_cells");

            entity.HasOne(d => d.User).WithMany(p => p.BloodTests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Blood_Tes__user___3B75D760");
        });

        modelBuilder.Entity<ExerciseTracking>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PK__Exercise__C121418ED30A26F8");

            entity.ToTable("Exercise_Tracking");

            entity.Property(e => e.ExerciseId)
                .ValueGeneratedNever()
                .HasColumnName("exercise_id");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("activity_type");
            entity.Property(e => e.CaloriesBurned)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("calories_burned");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ExerciseTrackings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Exercise___user___3E52440B");
        });

        modelBuilder.Entity<FamilyHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__Family_H__096AA2E90974856D");

            entity.ToTable("Family_History");

            entity.Property(e => e.HistoryId)
                .ValueGeneratedNever()
                .HasColumnName("history_id");
            entity.Property(e => e.AgeDiagnosed).HasColumnName("age_diagnosed");
            entity.Property(e => e.Condition)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("condition");
            entity.Property(e => e.RelativeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("relative_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.FamilyHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Family_Hi__user___46E78A0C");
        });

        modelBuilder.Entity<Immunization>(entity =>
        {
            entity.HasKey(e => e.ImmunizationId).HasName("PK__Immuniza__F4712B418A4CE20D");

            entity.Property(e => e.ImmunizationId)
                .ValueGeneratedNever()
                .HasColumnName("immunization_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VaccineName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vaccine_name");

            entity.HasOne(d => d.User).WithMany(p => p.Immunizations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Immunizat__user___4CA06362");
        });

        modelBuilder.Entity<InsuranceDetail>(entity =>
        {
            entity.HasKey(e => e.InsuranceId).HasName("PK__Insuranc__58B60F454A83E88B");

            entity.ToTable("Insurance_Details");

            entity.Property(e => e.InsuranceId)
                .ValueGeneratedNever()
                .HasColumnName("insurance_id");
            entity.Property(e => e.CoverageDetails)
                .HasColumnType("text")
                .HasColumnName("coverage_details");
            entity.Property(e => e.InsuranceCompany)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("insurance_company");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policy_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.InsuranceDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Insurance__user___49C3F6B7");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__Medical___BFCFB4DD613C48DD");

            entity.ToTable("Medical_Records");

            entity.Property(e => e.RecordId)
                .ValueGeneratedNever()
                .HasColumnName("record_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Diagnosis)
                .HasColumnType("text")
                .HasColumnName("diagnosis");
            entity.Property(e => e.DoctorNotes)
                .HasColumnType("text")
                .HasColumnName("doctor_notes");
            entity.Property(e => e.Treatment)
                .HasColumnType("text")
                .HasColumnName("treatment");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Medical_R__user___2A4B4B5E");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.MedicationId).HasName("PK__Medicati__DD94789B23FEE80B");

            entity.ToTable("Medication");

            entity.Property(e => e.MedicationId)
                .ValueGeneratedNever()
                .HasColumnName("medication_id");
            entity.Property(e => e.Dosage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dosage");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MedicationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("medication_name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Medications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Medicatio__user___35BCFE0A");
        });

        modelBuilder.Entity<Medication1>(entity =>
        {
            entity.HasKey(e => e.MedicationId).HasName("PK__Medicati__DD94789BFDEC13CE");

            entity.ToTable("Medications");

            entity.Property(e => e.MedicationId)
                .ValueGeneratedNever()
                .HasColumnName("medication_id");
            entity.Property(e => e.Dosage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dosage");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MedicationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("medication_name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Medication1s)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Medicatio__user___2D27B809");
        });

        modelBuilder.Entity<NutritionTracking>(entity =>
        {
            entity.HasKey(e => e.MealId).HasName("PK__Nutritio__2910B00FEF2A2DC5");

            entity.ToTable("Nutrition_Tracking");

            entity.Property(e => e.MealId)
                .ValueGeneratedNever()
                .HasColumnName("meal_id");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.Carbs)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("carbs");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Fats)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("fats");
            entity.Property(e => e.MealType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("meal_type");
            entity.Property(e => e.Proteins)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("proteins");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.NutritionTrackings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Nutrition__user___412EB0B6");
        });

        modelBuilder.Entity<SleepTracking>(entity =>
        {
            entity.HasKey(e => e.SleepId).HasName("PK__Sleep_Tr__8348CEBFA766968A");

            entity.ToTable("Sleep_Tracking");

            entity.Property(e => e.SleepId)
                .ValueGeneratedNever()
                .HasColumnName("sleep_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.SleepDuration)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("sleep_duration");
            entity.Property(e => e.SleepQuality).HasColumnName("sleep_quality");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WakeUpTimes).HasColumnName("wake_up_times");

            entity.HasOne(d => d.User).WithMany(p => p.SleepTrackings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sleep_Tra__user___440B1D61");
        });

        modelBuilder.Entity<SymptomsTracking>(entity =>
        {
            entity.HasKey(e => e.SymptomId).HasName("PK__Symptoms__7A85ADB87007F821");

            entity.ToTable("Symptoms_Tracking");

            entity.Property(e => e.SymptomId)
                .ValueGeneratedNever()
                .HasColumnName("symptom_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Severity).HasColumnName("severity");
            entity.Property(e => e.SymptomDescription)
                .HasColumnType("text")
                .HasColumnName("symptom_description");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.SymptomsTrackings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Symptoms___user___300424B4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F24CA9871");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61646BB63F26").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserProfileId).HasName("PK__User_Pro__151D386EF1FA69D6");

            entity.ToTable("User_Profile");

            entity.Property(e => e.UserProfileId)
                .ValueGeneratedNever()
                .HasColumnName("user_profile_id");
            entity.Property(e => e.Allergies)
                .HasColumnType("text")
                .HasColumnName("allergies");
            entity.Property(e => e.BloodType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("blood_type");
            entity.Property(e => e.ChronicConditions)
                .HasColumnType("text")
                .HasColumnName("chronic_conditions");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("height");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("weight");

            entity.HasOne(d => d.User).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__User_Prof__user___276EDEB3");
        });

        modelBuilder.Entity<Vital>(entity =>
        {
            entity.HasKey(e => e.VitalId).HasName("PK__Vitals__4DF3C4718607DEDF");

            entity.Property(e => e.VitalId)
                .ValueGeneratedNever()
                .HasColumnName("vital_id");
            entity.Property(e => e.BloodPressure)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("blood_pressure");
            entity.Property(e => e.BodyTemperature)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("body_temperature");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.HeartRate).HasColumnName("heart_rate");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Vitals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Vitals__user_id__32E0915F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
