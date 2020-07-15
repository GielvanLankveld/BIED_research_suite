using BIED_research_suite.Models.Database_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models
{
    public class ResponseViewModel
    {
        public Questionnaire questionnaire { get; set; }
        public Dataset dataset { get; set; }
    }
}
