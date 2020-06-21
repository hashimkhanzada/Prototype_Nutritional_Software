using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using FoodFilesSoftwareAssignment.Pages.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodFilesSoftwareAssignment
{
    public class SelectCustomFoodModel : IdentityUserDetails
    {
        private readonly IUserData _userData;
        private readonly ICalorieCountData _calorieCountData;
        private readonly IUserFoodData _userFoodData;
        private readonly ICustomFoodData _customFoodData;

        public List<SelectListItem> CustomFood { get; set; }

        [BindProperty]
        public UserFoodModel UserFood { get; set; }



        public SelectCustomFoodModel(IUserData userData, ICalorieCountData calorieCountData, IUserFoodData userFoodData, ICustomFoodData customFoodData)
        {
            _userData = userData;
            _calorieCountData = calorieCountData;
            _userFoodData = userFoodData;
            _customFoodData = customFoodData;
        }
        public async Task OnGet()
        {
            var food = await _customFoodData.GetAllCustomFood();

            CustomFood = new List<SelectListItem>();

            food.ForEach(x =>
            {
                CustomFood.Add(new SelectListItem { Value = x.CustomFoodId.ToString(), Text = x.ShortName });
            });
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            UserFood.UserId = UserId;
            UserFood.Date = TodayDate;

            await _userFoodData.InsertCustomFood(UserFood);

            return RedirectToPage("../DashBoard");
        }
    }
}