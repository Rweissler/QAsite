using System;
using System.Collections.Generic;
using System.Text;

namespace QA_site.Data
{
    public class Like
    {
        public int UserID { get; set; }
        public int QuestionID { get; set; }
        public Users User { get; set; }
        public Question Question { get; set; }
    }
}
