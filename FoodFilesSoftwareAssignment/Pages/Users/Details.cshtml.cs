﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodFilesSoftwareAssignment.Data;
using FoodFilesSoftwareAssignment.Models;

namespace FoodFilesSoftwareAssignment.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly FoodFilesSoftwareAssignment.Data.UserContext _context;

        public DetailsModel(FoodFilesSoftwareAssignment.Data.UserContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.ID == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
