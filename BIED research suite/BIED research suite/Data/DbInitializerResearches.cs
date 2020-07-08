using BIED_research_suite.Models;
using BIED_research_suite.Models.Database_entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace BIED_research_suite.Data
{
    public class DbInitializerResearches
    {
        public static void Initialize(ResearchesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Researches.Any())
            {
                return; //If this happens the DB already exists and has been seeded with test data
            }

            var researches = new Research[]
            {
                new Research {Title="Example research project"}
            };
            foreach (Research r in researches)
            {
                context.Researches.Add(r);
            }
            context.SaveChanges();

            var phases = new ResearchPhase[]
            {
                new ResearchPhase { ResearchPhaseID = 1, QuestionnaireID = 1}
            };
            foreach (ResearchPhase s in phases)
            {
                context.ResearchePhases.Add(s);
            }
            context.SaveChanges();
        }

    }
}
