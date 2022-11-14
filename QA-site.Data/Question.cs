using System;
using System.Collections.Generic;
using System.Text;

namespace QA_site.Data
{
   public class Question
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public List<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public int UserID { get; set; }
        public Users User { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
