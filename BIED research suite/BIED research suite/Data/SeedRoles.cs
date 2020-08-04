using BIED_research_suite.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BIED_research_suite.Data
{
    public static class SeedRoles
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in Enum.GetValues(typeof(RoleTypes)))
            {
                if (await roleManager.RoleExistsAsync(role.ToString()) == false)
                    await roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }            
        }
    }
}
