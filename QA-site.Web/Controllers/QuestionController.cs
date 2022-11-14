using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QA_site.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QA_site.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IConfiguration _configuration;
        public QuestionsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult AskQuestion()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AskQuestion(Question question, List<string> tags)
        {
            var repo = new QARepository(_configuration.GetConnectionString("ConStr"));
            var email = User.Identity.Name;
            question.UserID = repo.GetUserID(email);
            question.Date = DateTime.Now;
            repo.AddQuestion(question, tags);
            return Redirect("/home/index");
        }
        public IActionResult ViewQuestion(int id)
        {
            var repo = new QARepository(_configuration.GetConnectionString("ConStr"));
            var question = repo.GetQuestion(id);
            var vm = new ViewQuestionViewModel
            {
                Question = question,
                IsAuthenticated = User.Identity.IsAuthenticated,
                LikedQuestion = question.Likes.Any(l => l.User.Email == User.Identity.Name)
            };
            return View(vm);

        }

        [Authorize]
        [HttpPost]
        public IActionResult AddAnswer(Answer answer)
        {
            var repo = new QARepository(_configuration.GetConnectionString("ConStr"));
            answer.Date = DateTime.Now;
            answer.UserID = repo.GetUserID(User.Identity.Name);
            repo.AddAnswer(answer);
            return Redirect($"/questions/viewquestion?id={answer.QuestionID}");
        }

        public IActionResult GetQuestionLikes(int id)
        {
            var repo = new QARepository(_configuration.GetConnectionString("ConStr"));
            return Json(new { Likes = repo.GetLikes(id) });
        }

        [Authorize]
        [HttpPost]
        public void LikeQuestion(int questionID)
        {
            var repo = new QARepository(_configuration.GetConnectionString("ConStr"));
            var userID = repo.GetUserID(User.Identity.Name);
            var question = repo.GetQuestion(questionID);
            if (question.Likes.Any(l => l.UserID == userID))
            {
                return;
            }
            repo.LikeQuestion(userID, questionID);
        }
    }
}
}
