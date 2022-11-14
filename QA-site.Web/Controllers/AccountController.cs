using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QA_site.Data;
using System.Collections.Generic;
using System.Security.Claims;

namespace QA_site.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            if(TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"];
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var repo = new AccountRepository(_configuration.GetConnectionString("Constr");
            var user = repo.Login(email, password);
            if(user == null)
            {
                TempData["message"] = "Invalid Login!";
                return RedirectToAction("Login");
            }
            var claims = new List<Claim>
            {
                 new Claim(user, email)
            };
            HttpContext.SignInAsync(new ClaimsPrincipal(
             new ClaimsIdentity(claims, "Cookies", "user", "role"))).Wait();
            return Redirect("/home/index");
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Users user, string password)
        {
            var repo = new AccountRepository(_configuration.GetConnectionString("ConStr"));
            repo.AddUsers(user, password);
            return RedirectToAction("login");
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return Redirect("/");
        }
    }
}

              

        }
    }
}
