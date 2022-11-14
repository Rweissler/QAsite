using System;
using System.Collections.Generic;
using System.Text;

namespace QA_site.Data
{
   public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<QuestionTag> QuestionsTags { get; set; } = new List<QuestionTag>();
    }
}
