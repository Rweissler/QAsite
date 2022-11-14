using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QA_site.Data;
using QA_site.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QASite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var repo = new QARepository(_configuration.GetConnectionString("ConStr"));
            var vm = new HomePageViewModel
            {
                Questions = repo.GetQuestions()
            };
            return View(vm);
        }

    }
}