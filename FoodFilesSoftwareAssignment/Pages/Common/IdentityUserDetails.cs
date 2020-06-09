using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodFilesSoftwareAssignment.Pages.Common
{
    public class IdentityUserDetails:PageModel
    {
        public string UserId { get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
        public string UserName { get 
            {
                return User.FindFirstValue(ClaimTypes.Name);
            }
        }
    }
}
