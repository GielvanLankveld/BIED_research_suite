using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Models.Database_entities
{
    public class QuestionnaireItem
    {
        public int ID { get; set; }
        public string ItemText { get; set; }
        public ItemTypes ItemType { get; set; }
    }
}
