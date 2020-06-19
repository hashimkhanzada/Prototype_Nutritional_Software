using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using FoodFilesSoftwareAssignment.Pages.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using FoodFilesSoftwareAssignment.Models;

namespace FoodFilesSoftwareAssignment
{
    [Authorize]
    public class DashBoardModel : IdentityUserDetails
    {
        private readonly IUserData _userData;
        private readonly ICalorieCountData _calorieCountData;
        private readonly IUserFoodData _userFoodData;
        private readonly INzFoodFilesData _nzFoodFilesData;

        [BindProperty]
        public CalorieCountModel InitialUserCalories { get; set; } 

        [BindProperty]
        public CalorieCountModel CalorieCount { get; set; }

        [BindProperty]
        public List<UserFoodModel> UserFood { get; set; }

        [BindProperty]
        public List<NzFoodFilesModel> NzFoodFiles { get; set; }

        [BindProperty]
        public CalorieCountModel SelectedDate { get; set; }


        public DashBoardModel(IUserData userData, ICalorieCountData calorieCountData, IUserFoodData userFoodData, INzFoodFilesData nzFoodFilesData)
        {
            _userData = userData;
            _calorieCountData = calorieCountData;
            _userFoodData = userFoodData;
            _nzFoodFilesData = nzFoodFilesData;
        }

        public decimal caloriesConsumed = 0;
        public decimal carbohydrates = 0;
        public decimal sugar = 0;
        public decimal protein = 0;
        public decimal fat = 0;
        public decimal saturatedFat = 0;
        public decimal sodium = 0;

        public async Task<IActionResult> OnGet()
        {

            //gets data based on today's date
            CalorieCount = await _calorieCountData.GetCalorieCountByIdAndDate(UserId, TodayDate); //gets data from the caloriecount table based on userId and date, then inserts it into CalorieCount (instance of caloriecount model)
            UserFood = await _userFoodData.GetUserFoodByIdAndDate(UserId, TodayDate);

            NzFoodFiles = new List<NzFoodFilesModel>();

            if (CalorieCount is null) //creates new entry each time a user logs in, calorie goal is based on the goal from the last user entry
            {
                

                var recentUserCalories = await _calorieCountData.GetRecentCalorieGoal(UserId);

                InitialUserCalories = recentUserCalories;
                InitialUserCalories.UserId = UserId;
                InitialUserCalories.Date = DateTime.Today;

                await _calorieCountData.CreateCalorieCount(InitialUserCalories);

                return Page();
            }

            foreach (var item in UserFood) //displays total calories/macros of food displayed
            {
                string currentFoodId = item.FoodId;

                var food = await _nzFoodFilesData.GetNzFoodByFoodId(currentFoodId);

                caloriesConsumed += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Energy;
                carbohydrates += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Carbohydrates;
                sugar += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Sugar;
                protein += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Protein;
                fat += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Fat;
                saturatedFat += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().SaturatedFat;
                sodium += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Sodium;

                NzFoodFiles.AddRange(food);
            }



            return Page(); //refresh
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            

            //gets data based on date specified in the calendar
            CalorieCount = await _calorieCountData.GetCalorieCountByIdAndDate(UserId, SelectedDate.Date);

            UserFood = await _userFoodData.GetUserFoodByIdAndDate(UserId, SelectedDate.Date);

            NzFoodFiles = new List<NzFoodFilesModel>();

            foreach (var item in UserFood)
            {
                string currentFoodId = item.FoodId;

                var food = await _nzFoodFilesData.GetNzFoodByFoodId(currentFoodId);

                caloriesConsumed += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Energy;
                carbohydrates += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Carbohydrates;
                sugar += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Sugar;
                protein += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Protein;
                fat += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Fat;
                saturatedFat += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().SaturatedFat;
                sodium += item.Quantity * food.Where(x => x.FoodId == item.FoodId).First().Sodium;

                NzFoodFiles.AddRange(food);
            }

            return Page();
        }
    }
}