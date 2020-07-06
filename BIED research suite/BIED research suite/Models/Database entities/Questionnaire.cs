using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIED_research_suite.Models.Database_entities
{
    public class Questionnaire
    {
        public int QuestionnaireID { get; set; }
        public string Title { get; set; }
        public string IntroText { get; set; }
        public IList<QuestionnaireSection> QuestionnaireSections { get; set; }
    }
}
