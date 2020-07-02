using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models.Database_entities
{
    public class QuestionnaireResponseItem
    {
        public int ItemResponseID { get; set; }
        public ItemTypes ResponseType { get; set; }
        public string ResponseData { get; set; }
    }
}
