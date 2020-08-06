using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BIED_research_suite.Models.ViewModels
{
    public class UserViewModel
    {
        public IdentityUser user { get; set; }
        public List<string> roles { get; set; }
    }
}
