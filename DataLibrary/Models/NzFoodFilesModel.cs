using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class NzFoodFilesModel
    {
        public string FoodId { get; set; }
        public string ShortName { get; set; }
        public Decimal ServingSize { get; set; }
        public Decimal Energy { get; set; }
        public Decimal Carbohydrates { get; set; }
        public Decimal Protein { get; set; }
        public Decimal Fat { get; set; }
        public Decimal Sugar { get; set; }
        public Decimal Sodium { get; set; }
        public Decimal SaturatedFat { get; set; }
        public Decimal Fibre { get; set; }
    }
}
