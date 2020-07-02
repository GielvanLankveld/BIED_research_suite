using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models.Database_entities
{
    public class QuestionnaireResponseFullDataset
    {
        public int DatasetID { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string ParticipantID { get; set; }
        public ICollection<QuestionnaireResponseItem> AllItemResponses { get; set; }
    }
}
