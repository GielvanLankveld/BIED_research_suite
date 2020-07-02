using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models.Database_entities
{
    public class QuestionnaireSection
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string IntroText { get; set; }
        public ICollection<QuestionnaireItem> Items { get; set; }
    }
}
