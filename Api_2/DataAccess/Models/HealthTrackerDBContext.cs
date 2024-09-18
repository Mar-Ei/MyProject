using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class HealthTrackerDBContext : DbContext
    {
        public HealthTrackerDBContext()
        {
        }

        public HealthTrackerDBContext(DbContextOptions<HealthTrackerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allergy> Allergies { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; } = null!;
        public virtual DbSet<HealthRecord> HealthRecords { get; set; } = null!;
        public virtual DbSet<MedicalCondition> MedicalConditions { get; set; } = null!;
        public virtual DbSet<MedicalDiary> MedicalDiaries { get; set; } = null!;
        public virtual DbSet<Medication> Medications { get; set; } = null!;
        public virtual DbSet<MentalHealthLog> MentalHealthLogs { get; set; } = null!;
        public virtual DbSet<NutritionLog> NutritionLogs { get; set; } = null!;
        public virtual DbSet<PhysicalActivity> PhysicalActivities { get; set; } = null!;
        public virtual DbSet<Reminder> Reminders { get; set; } = null!;
        public virtual DbSet<SleepLog> SleepLogs { get; set; } = null!;
        public virtual DbSet<TestType> TestTypes { get; set; } = null!;
        public virtual DbSet<TestsResult> TestsResults { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserDoctorRelation> UserDoctorRelations { get; set; } = null!;
        public virtual DbSet<UserHealthGoal> UserHealthGoals { get; set; } = null!;
        public virtual DbSet<UserSetting> UserSettings { get; set; } = null!;
        public virtual DbSet<Vaccination> Vaccinations { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.Property(e => e.AllergyId).HasColumnName("allergy_id");

                entity.Property(e => e.AllergyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("allergy_name");

                entity.Property(e => e.Severity)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("severity");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Allergies)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Allergies__user___2E1BDC42");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("date")
                    .HasColumnName("appointment_date");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__docto__3A81B327");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Appointme__user___398D8EEE");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("specialization");
            });

            modelBuilder.Entity<EmergencyContact>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK__Emergenc__024E7A8656D751AE");

                entity.ToTable("Emergency_Contacts");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contact_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Relation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("relation");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmergencyContacts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Emergency__user___48CFD27E");
            });

            modelBuilder.Entity<HealthRecord>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PK__Health_R__BFCFB4DDF5BA7827");

                entity.ToTable("Health_Records");

                entity.Property(e => e.RecordId).HasColumnName("record_id");

                entity.Property(e => e.BloodPressure)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("blood_pressure");

                entity.Property(e => e.CholesterolLevel)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("cholesterol_level");

                entity.Property(e => e.HeartRate).HasColumnName("heart_rate");

                entity.Property(e => e.Height)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("height");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("date")
                    .HasColumnName("record_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("weight");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HealthRecords)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Health_Re__user___2B3F6F97");
            });

            modelBuilder.Entity<MedicalCondition>(entity =>
            {
                entity.HasKey(e => e.ConditionId)
                    .HasName("PK__Medical___8527AB15ED477B15");

                entity.ToTable("Medical_Conditions");

                entity.Property(e => e.ConditionId).HasColumnName("condition_id");

                entity.Property(e => e.ConditionName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("condition_name");

                entity.Property(e => e.DiagnosisDate)
                    .HasColumnType("date")
                    .HasColumnName("diagnosis_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MedicalConditions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Medical_C__user___4316F928");
            });

            modelBuilder.Entity<MedicalDiary>(entity =>
            {
                entity.HasKey(e => e.DiaryId)
                    .HasName("PK__Medical___339232C8483D3210");

                entity.ToTable("Medical_Diary");

                entity.Property(e => e.DiaryId).HasColumnName("diary_id");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("date")
                    .HasColumnName("entry_date");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.Symptoms)
                    .HasColumnType("text")
                    .HasColumnName("symptoms");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MedicalDiaries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Medical_D__user___286302EC");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.Property(e => e.MedicationId).HasColumnName("medication_id");

                entity.Property(e => e.Dosage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("dosage");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Frequency)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("frequency");

                entity.Property(e => e.MedicationName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("medication_name");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Medications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Medicatio__user___30F848ED");
            });

            modelBuilder.Entity<MentalHealthLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__Mental_H__9E2397E0CD4F45CB");

                entity.ToTable("Mental_Health_Logs");

                entity.Property(e => e.LogId).HasColumnName("log_id");

                entity.Property(e => e.LogDate)
                    .HasColumnType("date")
                    .HasColumnName("log_date");

                entity.Property(e => e.Mood)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mood");

                entity.Property(e => e.StressLevel).HasColumnName("stress_level");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MentalHealthLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Mental_He__user___5441852A");
            });

            modelBuilder.Entity<NutritionLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__Nutritio__9E2397E02501B944");

                entity.ToTable("Nutrition_Logs");

                entity.Property(e => e.LogId).HasColumnName("log_id");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Carbs)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("carbs");

                entity.Property(e => e.Fats)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("fats");

                entity.Property(e => e.LogDate)
                    .HasColumnType("date")
                    .HasColumnName("log_date");

                entity.Property(e => e.MealType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("meal_type");

                entity.Property(e => e.Protein)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("protein");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NutritionLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Nutrition__user___4E88ABD4");
            });

            modelBuilder.Entity<PhysicalActivity>(entity =>
            {
                entity.HasKey(e => e.ActivityId)
                    .HasName("PK__Physical__482FBD6381CA224C");

                entity.ToTable("Physical_Activity");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.ActivityDate)
                    .HasColumnType("date")
                    .HasColumnName("activity_date");

                entity.Property(e => e.ActivityType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("activity_type");

                entity.Property(e => e.CaloriesBurned).HasColumnName("calories_burned");

                entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PhysicalActivities)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Physical___user___4BAC3F29");
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.Property(e => e.ReminderId).HasColumnName("reminder_id");

                entity.Property(e => e.IsCompleted)
                    .HasColumnName("is_completed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReminderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("reminder_date");

                entity.Property(e => e.ReminderText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("reminder_text");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reminders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Reminders__user___571DF1D5");
            });

            modelBuilder.Entity<SleepLog>(entity =>
            {
                entity.HasKey(e => e.SleepId)
                    .HasName("PK__Sleep_Lo__8348CEBF412D6E1C");

                entity.ToTable("Sleep_Logs");

                entity.Property(e => e.SleepId).HasColumnName("sleep_id");

                entity.Property(e => e.HoursSlept)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("hours_slept");

                entity.Property(e => e.SleepDate)
                    .HasColumnType("date")
                    .HasColumnName("sleep_date");

                entity.Property(e => e.SleepQuality)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sleep_quality");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SleepLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Sleep_Log__user___5165187F");
            });

            modelBuilder.Entity<TestType>(entity =>
            {
                entity.ToTable("Test_Types");

                entity.Property(e => e.TestTypeId).HasColumnName("test_type_id");

                entity.Property(e => e.TestName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("test_name");
            });

            modelBuilder.Entity<TestsResult>(entity =>
            {
                entity.HasKey(e => e.TestResultId)
                    .HasName("PK__Tests_Re__152BCEDA0B097661");

                entity.ToTable("Tests_Results");

                entity.Property(e => e.TestResultId).HasColumnName("test_result_id");

                entity.Property(e => e.Result)
                    .HasColumnType("text")
                    .HasColumnName("result");

                entity.Property(e => e.TestDate)
                    .HasColumnType("date")
                    .HasColumnName("test_date");

                entity.Property(e => e.TestTypeId).HasColumnName("test_type_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.TestType)
                    .WithMany(p => p.TestsResults)
                    .HasForeignKey(d => d.TestTypeId)
                    .HasConstraintName("FK__Tests_Res__test___403A8C7D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TestsResults)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Tests_Res__user___3F466844");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E61646CB46873")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password_hash");
            });

            modelBuilder.Entity<UserDoctorRelation>(entity =>
            {
                entity.HasKey(e => e.RelationId)
                    .HasName("PK__User_Doc__C409F32364B62764");

                entity.ToTable("User_Doctor_Relation");

                entity.Property(e => e.RelationId).HasColumnName("relation_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.LastVisited)
                    .HasColumnType("date")
                    .HasColumnName("last_visited");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.UserDoctorRelations)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__User_Doct__docto__36B12243");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDoctorRelations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__User_Doct__user___35BCFE0A");
            });

            modelBuilder.Entity<UserHealthGoal>(entity =>
            {
                entity.HasKey(e => e.GoalId)
                    .HasName("PK__User_Hea__76679A244C4CB638");

                entity.ToTable("User_Health_Goals");

                entity.Property(e => e.GoalId).HasColumnName("goal_id");

                entity.Property(e => e.CurrentValue)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("current_value");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.GoalName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("goal_name");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.TargetValue)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("target_value");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserHealthGoals)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__User_Heal__user___5DCAEF64");
            });

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId)
                    .HasName("PK__User_Set__256E1E324CDE9531");

                entity.ToTable("User_Settings");

                entity.Property(e => e.SettingId).HasColumnName("setting_id");

                entity.Property(e => e.Language)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("language");

                entity.Property(e => e.NotificationPreference)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("notification_preference");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("time_zone");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSettings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__User_Sett__user___5AEE82B9");
            });

            modelBuilder.Entity<Vaccination>(entity =>
            {
                entity.Property(e => e.VaccinationId).HasColumnName("vaccination_id");

                entity.Property(e => e.BoosterDue)
                    .HasColumnType("date")
                    .HasColumnName("booster_due");

                entity.Property(e => e.DateGiven)
                    .HasColumnType("date")
                    .HasColumnName("date_given");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VaccineName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("vaccine_name");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vaccinations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Vaccinati__user___45F365D3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
