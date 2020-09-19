using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name,"sushil"),
                new Claim(ClaimTypes.Email,"sushil.may@gmail.com"),
                new Claim("Some Test","Test")
            };
            var identity = new ClaimsIdentity(claims,"Identity");

            var userPrinciple = new ClaimsPrincipal(new[] { identity });

            HttpContext.SignInAsync(userPrinciple);

            return RedirectToAction("Index");
        }
    }
}
