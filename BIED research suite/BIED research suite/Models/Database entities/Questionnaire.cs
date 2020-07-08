using System.Collections.Generic;

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
