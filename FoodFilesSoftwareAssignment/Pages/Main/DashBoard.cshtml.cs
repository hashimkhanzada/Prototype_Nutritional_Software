using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using FoodFilesSoftwareAssignment.Pages.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodFilesSoftwareAssignment
{
    public class DashBoardModel : IdentityUserDetails
    {
        private readonly IUserData _userData;
        private readonly ICalorieCountData _calorieCountData;

        public CalorieCountModel CalorieCount { get; set; }
        

        public DashBoardModel(IUserData userData, ICalorieCountData calorieCountData)
        {
            _userData = userData;
            _calorieCountData = calorieCountData;
        }

        public async Task<IActionResult> OnGet()
        {
            CalorieCount = await _calorieCountData.GetCalorieCountByIdAndDate(UserId, TodayDate);


            return Page();
        }



    }
}