using System;
using System.Collections.Generic;
using System.Text;

namespace QA_site.Data
{
   public class Answer
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public Users User { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
