using System;
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
    public class IndexModel : PageModel
    {
        private readonly FoodFilesSoftwareAssignment.Data.UserContext _context;

        public IndexModel(FoodFilesSoftwareAssignment.Data.UserContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
