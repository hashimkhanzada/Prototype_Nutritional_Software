using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodFilesSoftwareAssignment.Models
{
    public class DashboardDisplayModel
    {

        public string FoodId { get; set; }
        public string ShortName { get; set; }
        public decimal ServingSize { get; set; }
        public decimal Energy { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Protein { get; set; }
        public decimal Fat { get; set; }
        public decimal Sugar { get; set; }
        public decimal Sodium { get; set; }
        public decimal SaturatedFat { get; set; }
        public decimal Fibre { get; set; }
        public int UserFoodId { get; set; }
        public decimal Quantity { get; set; }
    }
}
