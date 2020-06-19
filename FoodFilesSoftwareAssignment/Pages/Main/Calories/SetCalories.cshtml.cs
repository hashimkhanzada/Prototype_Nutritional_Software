using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using FoodFilesSoftwareAssignment.Models;
using FoodFilesSoftwareAssignment.Pages.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodFilesSoftwareAssignment
{
    public class SetCaloriesModel : IdentityUserDetails
    {
        private readonly ICalorieCountData _calorieCountData;

        [BindProperty]
        public CalorieGoalModel UpdateCalorieGoal { get; set; }

        public SetCaloriesModel(ICalorieCountData calorieCountData)
        {
            _calorieCountData = calorieCountData;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            UpdateCalorieGoal.UserId = UserId;
            UpdateCalorieGoal.Date = TodayDate;

            
            await _calorieCountData.UpdateCalorieGoal(UpdateCalorieGoal.UserId, UpdateCalorieGoal.Date, UpdateCalorieGoal.CalorieGoal);

            return RedirectToPage("../DashBoard");
        }
    }
}