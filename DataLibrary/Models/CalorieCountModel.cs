using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class CalorieCountModel
    {
        public int CountId { get; set; }
        public string UserId { get; set; }
        public int CalorieGoal { get; set; }
        public DateTime Date { get; set; }
        public int CaloriesConsumed { get; set; }
        public int UserRecipeId { get; set; }
        public int UserFoodId { get; set; }
    }
}
