using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class CalorieCountModel
    {
        public int CountId { get; set; }
        public int UserId { get; set; }
        public int CalorieGoal { get; set; }
        public DateTime Date { get; set; }
        public int CaloriesConsumed { get; set; }
        public int RecipeId { get; set; }
        public int FoodId { get; set; }
    }
}
