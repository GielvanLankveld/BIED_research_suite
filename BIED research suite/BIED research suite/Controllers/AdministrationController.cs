using BIED_research_suite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BIED_research_suite.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController: Controller
    {
        private UserManager<IdentityUser> userManager;

        public AdministrationController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(userManager.Users);
        }

    }
}
