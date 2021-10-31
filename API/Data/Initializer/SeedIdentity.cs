using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Initializer
{
    public class SeedIdentity
    {
        public static async Task SeedUsers(UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/SeedData/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<ApplicationUser>>(userData);
            if (users == null) return;

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole{Name = "Admin"},               
                new ApplicationRole{Name = "Member"},
                new ApplicationRole{Name = "Moderator"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
            
            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");

                //if (user.UserName == "admin") { await userManager.AddToRoleAsync(user, "Admin"); }
                //if (user.UserName != "admin")
                //{
                //    await userManager.AddToRoleAsync(user, "Member");
                //}
                await userManager.AddToRoleAsync(user, "Member");
            }

            var admin = new ApplicationUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "$11f@17H");
            await userManager.AddToRolesAsync(admin, new[] {"Admin", "Moderator"});


            var frank = new ApplicationUser
            {
                UserName = "frank"
            };

            await userManager.CreateAsync(frank, "Admin613xyp@@");
            await userManager.AddToRolesAsync(frank, new[] {  "Member", "Moderator" });
        }
    }
}
