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
        private readonly IUserFoodData _userFoodData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public List<UserFoodModel> UserFood { get; set; }

        public RemoveFoodModel(IUserFoodData userFoodData)
        {
            _userFoodData = userFoodData;
        }


        public async Task<IActionResult> OnPost()
        {
            await _userFoodData.DeleteUserFood(Id);

            return RedirectToPage("../DashBoard");
        }
    }
}