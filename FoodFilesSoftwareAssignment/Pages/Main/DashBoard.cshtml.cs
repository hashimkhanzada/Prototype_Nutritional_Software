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
        private readonly IUserFoodData _userFoodData;
        private readonly INzFoodFilesData _nzFoodFilesData;



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

        public async Task<IActionResult> OnGet()
        {

            //gets data based on today's date
            CalorieCount = await _calorieCountData.GetCalorieCountByIdAndDate(UserId, TodayDate); //gets data from the caloriecount table based on userId and date, then inserts it into CalorieCount (instance of caloriecount model)
            UserFood = await _userFoodData.GetUserFoodByIdAndDate(UserId, TodayDate);

            NzFoodFiles = new List<NzFoodFilesModel>();

            foreach (var item in UserFood)
            {
                string currentFoodId = item.FoodId;

                var abc = await _nzFoodFilesData.GetNzFoodByFoodId(currentFoodId);

                NzFoodFiles.AddRange(abc);
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

                var abc = await _nzFoodFilesData.GetNzFoodByFoodId(currentFoodId);

                NzFoodFiles.AddRange(abc);
            }

            return Page();
        }


    }
}