using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class NzFoodFiles
    {
        public string FoodId { get; set; }
        public string ShortName { get; set; }
        public int ServingSize { get; set; }
        public int Energy { get; set; }
        public int Carbohydrates { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Sugar { get; set; }
        public int Sodium { get; set; }
        public int SaturatedFat { get; set; }
        public int Fibre { get; set; }
    }
}
