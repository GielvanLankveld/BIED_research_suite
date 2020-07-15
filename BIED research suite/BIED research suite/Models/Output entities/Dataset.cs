using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models.Database_entities
{
    public class Dataset
    {
        public int DatasetID { get; set; }
        public int QuestionnaireID { get; set; }
        public string ParticipantID { get; set; }
        public DateTime SubmissionDate { get; set; }
        public ICollection<Response> Responses { get; set; }
    }
}
