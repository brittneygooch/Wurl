using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wurl.Data.Model;

namespace Wurl.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db)
        {
            // generic Identity - Store the users
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            // generic Identity - roles
            RoleStore<Role> roleStore = new RoleStore<Role>(db);
            RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);

            ApplicationUser userOne = null;
            userOne = userManager.FindByName("abeth");

            if (userOne == null)
            {
                userManager.Create(new ApplicationUser
                {
                    Email = "abeth1986@outlook.com",
                    DisplayName = "Andrew",
                    Country = "United Kingdom",
                    City = "London",
                    Continent = "Europe",
                    UserName = "abeth"
                }, "123456");
                userOne = userManager.FindByName("abeth");
            }

            // if ROLES does not exist, do create them
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new Role { Name = "Admin" });
                roleManager.Create(new Role { Name = "General" });
            }

            // assign the userOne into a role
            if (!userManager.IsInRole(userOne.Id, "Admin"))
            {
                userManager.AddToRole(userOne.Id, "Admin");
            }
        }
    }
}
