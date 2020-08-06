using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models.Database_entities
{
    public class ResearchPhase
    {
        public int ResearchPhaseID { get; set; }
        public int ResearchID { get; set; }
        public int QuestionnaireID { get; set; }
        public DateTime StartTime { get; set; }
    }
}
