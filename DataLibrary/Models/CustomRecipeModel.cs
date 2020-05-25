using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class CustomRecipeModel
    {
        public int RecipeId { get; set; }
        public int Calories { get; set; }
        public int FoodId { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeName { get; set; }
        public string ServingSize { get; set; }
        public int UserId { get; set; }
    }
}
