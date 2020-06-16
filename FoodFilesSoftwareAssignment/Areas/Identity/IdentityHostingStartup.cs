using System;
using FoodFilesSoftwareAssignment.Areas.Identity.Data;
using FoodFilesSoftwareAssignment.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

[assembly: HostingStartup(typeof(FoodFilesSoftwareAssignment.Areas.Identity.IdentityHostingStartup))]
namespace FoodFilesSoftwareAssignment.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FFSA_AuthDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FFSA_AuthDBContextConnection")));
                
                services.AddDefaultIdentity<FFSA_ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 5;
                })
                
                    .AddEntityFrameworkStores<FFSA_AuthDBContext>();
            });
        }
    }
}