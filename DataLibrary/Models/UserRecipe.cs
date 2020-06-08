using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class UserRecipe
    {
        public int UserRecipeId { get; set; }
        public string UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
