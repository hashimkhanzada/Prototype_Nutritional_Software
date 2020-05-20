using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodFilesSoftwareAssignment.Models;

namespace FoodFilesSoftwareAssignment.Data
{
    public class UserContext : DbContext
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<FoodFilesSoftwareAssignment.Models.User> User { get; set; }
    }
}
