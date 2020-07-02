using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models.Database_entities
{
    public class QuestionnaireSection
    {        
        public int SectionID { get; set; }
        public string Title { get; set; }
        public string IntroText { get; set; }
        public ICollection<QuestionnaireItem> Items { get; set; }
    }
}
