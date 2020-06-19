using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFilesSoftwareAssignment.Models
{
    public class CalorieGoalModel
    {

        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal CalorieGoal { get; set; }
    }
}
