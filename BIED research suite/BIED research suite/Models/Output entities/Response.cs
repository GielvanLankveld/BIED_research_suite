using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models.Database_entities
{
    public class Response
    {
        public int ResponseID { get; set; }
        public int DatasetID { get; set; }
        public ItemTypes ResponseType { get; set; }
        public string Data { get; set; }
    }
}
