using BIED_research_suite.Models;
using BIED_research_suite.Models.Database_entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace BIED_research_suite.Data
{
    public class DbInitializerQuestionnaires
    {
        public static void Initialize(QuestionnairesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Questionnaires.Any())
            {
                return; //If this happens the DB already exists and has been seeded with test data
            }

            var questionnaires = new Questionnaire[]
            {
                new Questionnaire {Title="Example questionnaire", IntroText="A questionnaire on an example topic"}
            };
            foreach (Questionnaire q in questionnaires)
            {
                context.Questionnaires.Add(q);
            }
            context.SaveChanges();

            var sections = new QuestionnaireSection[]
            {
                new QuestionnaireSection {QuestionnaireID=1,Title="Section 1", IntroText="Intro 1"},
                new QuestionnaireSection {QuestionnaireID=1,Title="Section 2", IntroText="Intro 2"}
            };
            foreach (QuestionnaireSection s in sections)
            {
                context.QuestionnaireSections.Add(s);
            }
            context.SaveChanges();

            var items = new QuestionnaireItem[]
            {
                new QuestionnaireItem {QuestionnaireSectionID=1, ItemText="Item 1", ItemType=ItemTypes.Text},
                new QuestionnaireItem {QuestionnaireSectionID=1, ItemText="Item 2", ItemType=ItemTypes.Value},
                new QuestionnaireItem {QuestionnaireSectionID=1, ItemText="Item 3", ItemType=ItemTypes.Likert},

                new QuestionnaireItem {QuestionnaireSectionID=2, ItemText="Item 4", ItemType=ItemTypes.Text},
                new QuestionnaireItem {QuestionnaireSectionID=2, ItemText="Item 5", ItemType=ItemTypes.Value},
                new QuestionnaireItem {QuestionnaireSectionID=2, ItemText="Item 6", ItemType=ItemTypes.Likert}
            };
            foreach (QuestionnaireItem i in items)
            {
                context.QuestionnaireItems.Add(i);
            }
            context.SaveChanges();
        }

    }
}
