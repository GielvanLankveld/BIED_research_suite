using BIED_research_suite.Models.Database_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models.ViewModels
{
    public class QuestionnaireViewModel
    {
        public IEnumerable<Questionnaire> Questionnaires { get; set; }
        public IEnumerable<QuestionnaireSection> QuestionnaireSections { get; set; }
        public IEnumerable<QuestionnaireItem> QuestionnaireItems { get; set; }
    }
}
