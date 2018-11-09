using Microsoft.AspNetCore.Identity;
using SantaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantaAPI.Data
{
    public class SeedData
    {

        public static async Task Initialize(
                ApplicationDbContext context,
                UserManager<ApplicationUser> userManager,
                RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            string adminRole = "Admin";
            string desc1 = "This is the administrator role";

            string childRole = "Child";
            string desc2 = "This is the child role";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(adminRole, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(childRole) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(childRole, desc2, DateTime.Now));
            }

            // create admin user
            if (await userManager.FindByNameAsync("santa") == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Santa",
                    LastName = "Clause",
                    BirthDate = new DateTime(1950, 12, 14),
                    Street = "North Pole",
                    City = "North Pole",
                    Province = "NP",
                    PostalCode = "H0H 0H0",
                    Country = "Canada",
                    Latitude = 80,
                    Longitude = 72,
                    IsNaughty = false,
                    DateCreated = DateTime.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    Email = "santa@np.com",
                    UserName = "santa",
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }

            // create member user
            if (await userManager.FindByNameAsync("tim") == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Tim",
                    LastName = "Smith",
                    BirthDate = new DateTime(2010, 4, 21),
                    Street = "123 Alpha St",
                    City = "Vancouver",
                    Province = "BC",
                    PostalCode = "V5A 2S3",
                    Country = "Canada",
                    Latitude = 49,
                    Longitude = 123,
                    IsNaughty = false,
                    DateCreated = DateTime.UtcNow,
                    CreatedBy = Guid.NewGuid(),
                    Email = "tim@np.com",
                    UserName = "tim",
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, childRole);
                }
            }
        }
    }
}
