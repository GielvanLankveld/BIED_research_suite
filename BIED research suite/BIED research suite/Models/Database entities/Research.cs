using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models.Database_entities
{
    public class Research
    {
        public int ResearchID { get; set; }
        public string Title { get; set; }
        public DateTime StartingDateTime { get; set; }
        public DateTime EndingDateTime { get; set; }
        public IdentityUser PrincipalInvestigator { get; set; }
        public IList<ResearchPhase> ResearchPhases { get; set; }
        public IList<IdentityUser> Participants { get; set; }
    }
}
