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
using Microsoft.AspNetCore.Authorization;

namespace FoodFilesSoftwareAssignment
{
    [Authorize]
    public class SelectFoodModel : IdentityUserDetails
    {
        private readonly IUserData _userData;
        private readonly ICalorieCountData _calorieCountData;
        private readonly IUserFoodData _userFoodData;
        private readonly INzFoodFilesData _nzFoodFilesData;



        public List<SelectListItem> NzFoodFiles { get; set; }

        [BindProperty]
        public List<CustomFoodModel> CustomFood { get; set; }
        [BindProperty]
        public UserFoodModel UserFood { get; set; }



        public SelectFoodModel(IUserData userData, ICalorieCountData calorieCountData, IUserFoodData userFoodData, INzFoodFilesData nzFoodFilesData)
        {
            _userData = userData;
            _calorieCountData = calorieCountData;
            _userFoodData = userFoodData;
            _nzFoodFilesData = nzFoodFilesData;
        }



        public async Task OnGet()
        {
            var food = await _nzFoodFilesData.GetAllFood();

            NzFoodFiles = new List<SelectListItem>();

            food.ForEach(x =>
            {
                NzFoodFiles.Add(new SelectListItem { Value = x.FoodId, Text = x.ShortName });
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

            await _userFoodData.InsertFood(UserFood);

            return RedirectToPage("../DashBoard");
        }
    }
}