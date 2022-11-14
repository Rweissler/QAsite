using System;
using System.Collections.Generic;
using System.Text;

namespace QA_site.Data
{
   public class QuestionTag
    {
        public int QuestionID { get; set; }
        public int TagID { get; set; }
        public Question Question { get; set; }
        public Tag Tag { get; set; }
    }
}
