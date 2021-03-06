﻿using BIED_research_suite.Models;
using BIED_research_suite.Models.Database_entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIED_research_suite.Data
{
    public class DbInitializerDatasets
    {
        public static async void Initialize(DatasetsContext dsContext, QuestionnairesContext qContext, UserManager<IdentityUser> userManager)
        {
            dsContext.Database.EnsureCreated();

            if (dsContext.Datasets.Any())
            {
                return; //If this happens the DB already exists and has been seeded with test data
            }

            var deelnemers = await userManager.GetUsersInRoleAsync("Deelnemer");

            string participant = "Dummy";
            if (deelnemers.Count > 0)
            {
                participant = deelnemers[0].Id;
            }

            dsContext.Datasets.Add(new Dataset {
                ResearchID = 1,
                ResearchPhaseID = 1,
                QuestionnaireID = 1,
                ParticipantID = participant,
                SubmissionDate = DateTime.Now
            });
            dsContext.SaveChanges();

            var questionnaire = qContext.Questionnaires
                .FirstOrDefault();

            var responses = new List<Response>();
            foreach (var section in questionnaire.QuestionnaireSections)
            {
                foreach (var item in section.QuestionnaireItems)
                {
                    new Response
                    {
                        ResponseID = responses.Count + 1,
                        DatasetID = 1,
                        ResponseType = item.ItemType,
                        Data = item.QuestionnaireItemID.ToString()
                    };
                }
            }
            foreach (Response r in responses)
            {
                dsContext.Responses.Add(r);
            }
            dsContext.SaveChanges();
        }

    }
}
