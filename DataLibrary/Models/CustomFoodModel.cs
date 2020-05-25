using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class CustomFoodModel
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public string ServingSize { get; set; }
        public int UserId { get; set; }
    }
}
