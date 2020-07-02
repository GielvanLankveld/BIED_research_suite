using BIED_research_suite.Models;
using BIED_research_suite.Models.Database_entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Data
{
    public class DbInitializer
    {
        public static void Initialize(QuestionnairesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Questionnaires.Any())
            {
                return; //If this happens the DB already exists and has been seeded with test data
            }

            var items = new QuestionnaireItem[]
            {
                new QuestionnaireItem {ItemText="Item 1", ItemType=ItemTypes.Text},
                new QuestionnaireItem {ItemText="Item 2", ItemType=ItemTypes.Text},
                new QuestionnaireItem {ItemText="Item 3", ItemType=ItemTypes.Value},
                new QuestionnaireItem {ItemText="Item 4", ItemType=ItemTypes.Value},
                new QuestionnaireItem {ItemText="Item 5", ItemType=ItemTypes.Likert},
                new QuestionnaireItem {ItemText="Item 6", ItemType=ItemTypes.Likert}
            };
            foreach (QuestionnaireItem i in items)
            {
                context.Items.Add(i);
            }

            var sections = new QuestionnaireSection[]
            {
                new QuestionnaireSection {Title="Section 1", IntroText="Intro 1"},
                new QuestionnaireSection {Title="Section 2", IntroText="Intro 2"}
            };
            foreach (QuestionnaireSection s in sections)
            {
                context.Sections.Add(s);
            }

            var questionnaires = new Questionnaire[]
            {
                new Questionnaire {Title="Example questionnaire", IntroText="A questionnaire on an example topic", PresentationTime=DateTime.Parse("2020-07-10")}
            };
            foreach (Questionnaire q in questionnaires)
            {
                context.Questionnaires.Add(q);
            }

            context.SaveChanges();
        }

    }
}
