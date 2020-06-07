using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodFilesSoftwareAssignment.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodFilesSoftwareAssignment.Data
{
    public class FFSA_AuthDBContext : IdentityDbContext<FFSA_ApplicationUser>
    {
        public FFSA_AuthDBContext(DbContextOptions<FFSA_AuthDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
