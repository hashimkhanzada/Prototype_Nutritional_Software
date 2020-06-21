using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
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

        public CalorieCountModel CalorieCount { get; set; }

        public SetCaloriesModel(ICalorieCountData calorieCountData)
        {
            _calorieCountData = calorieCountData;
        }

        public async Task<IActionResult> OnGet()
        {

            //gets data based on today's date
            CalorieCount = await _calorieCountData.GetCalorieCountByIdAndDate(UserId, TodayDate); //gets data from the caloriecount table based on userId and date, then inserts it into CalorieCount (instance of caloriecount model)

            return Page();
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