using BIED_research_suite.Models.Database_entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BIED_research_suite.Models.ViewModels
{
    public class ResearchCreationViewModel
    {
        public Research newResearch { get; set; }
        public List<IdentityUser> researchers { get; set; }
    }
}
