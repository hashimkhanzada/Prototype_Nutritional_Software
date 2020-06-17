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


        [BindProperty] //write to the user model through post methods
        public UserModel UserDetails { get; set; }  //Instance of UserModel through which data will be entered into the sql database, it will stored data that we create in this class
        
        [BindProperty]
        public CalorieCountModel InitialUserCalories { get; set; } //instance of caloriecountModel. Initial user data that will be inserted into the calorie count table when registering


        //constructor
        public CreateUserModel(IUserData userData, ICalorieCountData calorieCountData)
        {
            _userData = userData;
            _calorieCountData = calorieCountData;
        }

        public async Task<IActionResult> OnPost()
        {
            //if there's an error in the model, return page
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            UserDetails.Id = UserId; //UserId has been retrieved from the Identity database. Done in the inherited class
            UserDetails.UserName = UserName; //gets username from identity database. Done in inherited class

            //TODO - shift to class library, add variables instead of hard-coded data
            Decimal CalorieFormula = InitialUserCalories.CalorieGoal = (10 * UserDetails.Weight) + (6.25m * UserDetails.Height) - (5 * UserDetails.Age); //formula to calculate TDEE, will be altered, and will be shifted to the class library so it can be reused.

            //TODO - change form so it has a drop down for this data, not textbox 
            //input in the form is hard coded
            if (UserDetails.Gender == "Male") {
                InitialUserCalories.CalorieGoal = CalorieFormula + 5;
            }
            else if (UserDetails.Gender == "Female")
            {
                InitialUserCalories.CalorieGoal = CalorieFormula - 161;
            }

            //data entered into the caloriecount table
            InitialUserCalories.UserId = UserId;
            InitialUserCalories.Date = DateTime.Today;

            //queries executed here
            await _userData.CreateUserDetails(UserDetails); //Takes data from the UserDetails model and inserts it into the User table
            await _calorieCountData.CreateCalorieCount(InitialUserCalories); //Takes data from the InitialUserCalories model and inserts it into the caloriecount table

            return RedirectToPage("../Main/DashBoard");
        }
    }
}