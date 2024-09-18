using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class NutritionLog
    {
        public int LogId { get; set; }
        public int? UserId { get; set; }
        public DateTime? LogDate { get; set; }
        public string? MealType { get; set; }
        public int? Calories { get; set; }
        public decimal? Protein { get; set; }
        public decimal? Carbs { get; set; }
        public decimal? Fats { get; set; }

        public virtual User? User { get; set; }
    }
}
