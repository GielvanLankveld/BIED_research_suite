using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace BIED_research_suite.Data
{
    public class DbInitializerIdentity
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            //Check if the administrator and researcher roles exist
            if (!context.Roles.Contains<IdentityRole>(new IdentityRole { Id = "administrator" }))
            {
                context.Roles.Add(new IdentityRole { Id = "administrator", Name = "Administrator" });
                context.SaveChanges();
            }
            if (!context.Roles.Contains<IdentityRole>(new IdentityRole { Id = "onderzoeker" }))
            {
                context.Roles.Add(new IdentityRole { Id = "onderzoeker", Name = "Onderzoeker" });
                context.SaveChanges();
            }
            if (!context.Roles.Contains<IdentityRole>(new IdentityRole { Id = "deelnemer" }))
            {
                context.Roles.Add(new IdentityRole { Id = "deelnemer", Name = "Deelnemer" });
                context.SaveChanges();
            }

            //var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context),new IdentityOptions(), new PasswordHasher<IdentityUser>());

            // Check if the administrator user exists
            if (!context.Users.Contains<IdentityUser>(new IdentityUser { UserName = "Administrator"}))
            {
                // Add the administrator user
                IdentityUser admin = new IdentityUser { Email = "administrator@email.com", NormalizedEmail = "ADMINISTRATOR@EMAIL.COM", EmailConfirmed = true, UserName = "Administrator", NormalizedUserName = "ADMINISTRATOR", PasswordHash = "AQAAAAEAACcQAAAAEMEPXSA/VROK4VJH5HRZ1Dje2oGdnrtch9OjV4cA+ccVhKMjJF+fOa4nQvZJeGHPzg==" };
                context.Users.Add(admin);
                context.SaveChanges();

                var users = context.Users.ToList();
                admin = users.Find(u => u.UserName == "Administrator");

                context.UserRoles.Add(new IdentityUserRole<string>() { RoleId = "administrator", UserId = admin.Id });
                context.SaveChanges();
            }

            // Check if the researcher user exists
            if (!context.Users.Contains<IdentityUser>(new IdentityUser { UserName = "Onderzoeker" }))
            {
                // Add the onderzoeker user
                IdentityUser onderzoeker = new IdentityUser { Email = "onderzoeker@email.com", NormalizedEmail = "ONDERZOEKER@EMAIL.COM", EmailConfirmed = true, UserName = "Onderzoeker", NormalizedUserName = "ONDERZOEKER", PasswordHash = "AQAAAAEAACcQAAAAEPToq80vROeKJNRKieLR3NCWpC0IdtZHKmr1tLqP2F+C4CkJwwBamN84WAVpOEuNyg==" };
                context.Users.Add(onderzoeker);
                context.SaveChanges();

                var users = context.Users.ToList();
                onderzoeker = users.Find(u => u.UserName == "Onderzoeker");

                context.UserRoles.Add(new IdentityUserRole<string>() { RoleId = "onderzoeker", UserId = onderzoeker.Id });
                context.SaveChanges();
            }
        }
    }
}
