using System;
using System.Collections.Generic;

namespace QA_site.Data
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public object QuestionTags { get; internal set; }
    }
}
