using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using FoodFilesSoftwareAssignment.Pages.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodFilesSoftwareAssignment
{
    public class CreateUserModel : IdentityUserDetails
    {
        private readonly IUserData _userData;
        private readonly ICalorieCountData _calorieCountData;

        [BindProperty]
        public UserModel UserDetails { get; set; }

        [BindProperty]
        public CalorieCountModel InitialUserCalories { get; set; }

        public CreateUserModel(IUserData userData, ICalorieCountData calorieCountData)
        {
            _userData = userData;
            _calorieCountData = calorieCountData;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            UserDetails.Id = UserId; //gets id from identity database
            UserDetails.UserName = UserName; //gets username from identity database


            int CalorieFormula = InitialUserCalories.CalorieGoal = Convert.ToInt32((10 * UserDetails.Weight) + (6.25 * UserDetails.Height) - (5 * UserDetails.Age));

            if (UserDetails.Gender == "Male") {
                InitialUserCalories.CalorieGoal = CalorieFormula + 5;
            }
            else if (UserDetails.Gender == "Female")
            {
                InitialUserCalories.CalorieGoal = CalorieFormula - 161;
            }

            InitialUserCalories.UserId = UserId;
            InitialUserCalories.Date = DateTime.Today;

            await _userData.CreateUserDetails(UserDetails);
            await _calorieCountData.CreateCalorieCount(InitialUserCalories);

            return RedirectToPage("../Main/DashBoard");
        }
    }
}