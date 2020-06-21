using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodFilesSoftwareAssignment
{
    [Authorize]
    public class AddFoodModel : PageModel
    {
        private readonly IUserData _userData;
        private readonly ICalorieCountData _calorieCountData;
        private readonly IUserFoodData _userFoodData;
        private readonly INzFoodFilesData _nzFoodFilesData;
        private readonly ICustomFoodData _customFoodData;

        [BindProperty]
        public CustomFoodModel CustomFood { get; set; }

        public AddFoodModel(IUserData userData, ICalorieCountData calorieCountData, IUserFoodData userFoodData, INzFoodFilesData nzFoodFilesData, ICustomFoodData customFoodData)
        {
            _userData = userData;
            _calorieCountData = calorieCountData;
            _userFoodData = userFoodData;
            _nzFoodFilesData = nzFoodFilesData;
            _customFoodData = customFoodData;
        }



        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _customFoodData.CreateCustomFood(CustomFood);

            return RedirectToPage("../DashBoard");
        }
    }
}