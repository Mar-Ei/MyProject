using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class NutritionTracking
{
    public int MealId { get; set; }

    public int? UserId { get; set; }

    public string MealType { get; set; } = null!;

    public int Calories { get; set; }

    public decimal? Proteins { get; set; }

    public decimal? Fats { get; set; }

    public decimal? Carbs { get; set; }

    public DateOnly Date { get; set; }

    public virtual User? User { get; set; }
}
