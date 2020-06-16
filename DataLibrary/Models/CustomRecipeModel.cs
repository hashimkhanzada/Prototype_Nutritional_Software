using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class CustomRecipeModel
    {
        public int RecipeId { get; set; }
        public Decimal Calories { get; set; }
        public string FoodId { get; set; }
        public int CustomFoodId { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeName { get; set; }
        public Decimal ServingSize { get; set; }
        public string UserId { get; set; }
    }
}
