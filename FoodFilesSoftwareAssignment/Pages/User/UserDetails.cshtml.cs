using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodFilesSoftwareAssignment
{
    public class CreateUserModel : PageModel
    {
        private readonly IUserData _userData;

        [BindProperty]
        public UserModel UserDetails { get; set; }
        public string UserId { get; set; }

        public CreateUserModel(IUserData userData)
        {
            _userData = userData;
        }
        public void OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        //public async Task<IActionResult> OnPost()
        //{

        //}
    }
}