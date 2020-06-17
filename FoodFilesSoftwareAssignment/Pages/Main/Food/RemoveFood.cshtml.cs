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
    public class RemoveFoodModel : IdentityUserDetails
    {
        private readonly IUserData _userData;
        private readonly ICalorieCountData _calorieCountData;
        private readonly IUserFoodData _userFoodData;
        private readonly INzFoodFilesData _nzFoodFilesData;

        //working on this page

        [BindProperty]
        public List<UserFoodModel> UserFood { get; set; }
        [BindProperty]
        public List<NzFoodFilesModel> NzFoodFiles { get; set; }

        public RemoveFoodModel(IUserData userData, ICalorieCountData calorieCountData, IUserFoodData userFoodData, INzFoodFilesData nzFoodFilesData)
        {
            _userData = userData;
            _calorieCountData = calorieCountData;
            _userFoodData = userFoodData;
            _nzFoodFilesData = nzFoodFilesData;
        }

        public async Task<IActionResult> OnGet()
        {
            UserFood = await _userFoodData.GetUserFoodByIdAndDate(UserId, TodayDate);

            return Page();
        }
    }
}