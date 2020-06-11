using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodFilesSoftwareAssignment.Pages.Common
{
    public class IdentityUserDetails:PageModel 
    {
        //these variables are used by pages that inherit this class
        public string UserId { get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier); //gets the userId of the user who's logged in
            }
        }
        public string UserName { get 
            {
                return User.FindFirstValue(ClaimTypes.Name);
            }
        }
        public DateTime TodayDate { get
            {
                return DateTime.Today; //gets current data
            }
        }

    }
}
