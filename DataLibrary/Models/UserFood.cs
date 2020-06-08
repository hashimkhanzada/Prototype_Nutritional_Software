using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class UserFood
    {
        public int UserFoodId { get; set; }
        public string UserId { get; set; }
        public string FoodId { get; set; }
        public int CustomFoodId { get; set; }
    }
}
