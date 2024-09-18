using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Allergies = new HashSet<Allergy>();
            Appointments = new HashSet<Appointment>();
            EmergencyContacts = new HashSet<EmergencyContact>();
            HealthRecords = new HashSet<HealthRecord>();
            MedicalConditions = new HashSet<MedicalCondition>();
            MedicalDiaries = new HashSet<MedicalDiary>();
            Medications = new HashSet<Medication>();
            MentalHealthLogs = new HashSet<MentalHealthLog>();
            NutritionLogs = new HashSet<NutritionLog>();
            PhysicalActivities = new HashSet<PhysicalActivity>();
            Reminders = new HashSet<Reminder>();
            SleepLogs = new HashSet<SleepLog>();
            TestsResults = new HashSet<TestsResult>();
            UserDoctorRelations = new HashSet<UserDoctorRelation>();
            UserHealthGoals = new HashSet<UserHealthGoal>();
            UserSettings = new HashSet<UserSetting>();
            Vaccinations = new HashSet<Vaccination>();
        }

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Allergy> Allergies { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; }
        public virtual ICollection<HealthRecord> HealthRecords { get; set; }
        public virtual ICollection<MedicalCondition> MedicalConditions { get; set; }
        public virtual ICollection<MedicalDiary> MedicalDiaries { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }
        public virtual ICollection<MentalHealthLog> MentalHealthLogs { get; set; }
        public virtual ICollection<NutritionLog> NutritionLogs { get; set; }
        public virtual ICollection<PhysicalActivity> PhysicalActivities { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
        public virtual ICollection<SleepLog> SleepLogs { get; set; }
        public virtual ICollection<TestsResult> TestsResults { get; set; }
        public virtual ICollection<UserDoctorRelation> UserDoctorRelations { get; set; }
        public virtual ICollection<UserHealthGoal> UserHealthGoals { get; set; }
        public virtual ICollection<UserSetting> UserSettings { get; set; }
        public virtual ICollection<Vaccination> Vaccinations { get; set; }
    }
}
