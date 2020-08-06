using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace BIED_research_suite.Data
{
    public class DbInitializerIdentity
    {
        public static async void Initialize(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (userManager.Users.Any())
            {
                return;
            }

            await SeedRoles.SeedRolesAsync(roleManager);

            var admin = new IdentityUser
            {
                UserName = "administrator@email.com",
                NormalizedUserName = "ADMINISTRATOR@EMAIL.COM",
                Email = "administrator@email.com",
                NormalizedEmail = "ADMINISTRATOR@EMAIL.COM",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(admin, "Test1!");
            if (await userManager.IsInRoleAsync(admin, "Administrator") == false)
            {
                await userManager.AddToRoleAsync(admin, "Administrator");
            }

            var onderzoeker = new IdentityUser
            {
                UserName = "onderzoeker@email.com",
                NormalizedUserName = "ONDERZOEKER",
                Email = "ONDERZOEKER@EMAIL.COM",
                NormalizedEmail = "ONDERZOEKER@EMAIL.COM",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(onderzoeker, "Test1!");
            if (await userManager.IsInRoleAsync(onderzoeker, "Onderzoeker") == false)
            {
                await userManager.AddToRoleAsync(onderzoeker, "Onderzoeker");
            }

            var deelnemer = new IdentityUser
            {
                UserName = "deelnemer@email.com",
                NormalizedUserName = "DEELNEMER@EMAIL.COM",
                Email = "deelnemer@email.com",
                NormalizedEmail = "DEELNEMER@EMAIL.COM",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(deelnemer, "Test1!");
            if (await userManager.IsInRoleAsync(deelnemer, "Deelnemer") == false)
            {
                await userManager.AddToRoleAsync(deelnemer, "Deelnemer");
            }
        }
    }
}
