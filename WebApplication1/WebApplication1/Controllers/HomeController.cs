using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authentication;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> LogInAsPetya()
        {
            string name = "Petya";
            return await LogInAs(name);
        }

        public async Task<IActionResult> LogInAsVasya()
        {
            string name = "Vasya";
            return await LogInAs(name);
        }

        [Authorize("OnlyForPetyas")]
        public IActionResult PetyasOnly()
        {
            return Content("Info only for Petyas");
        }

        private async Task<IActionResult> LogInAs(string name)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, name) };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            //as I understand - any value can go for the second parameter.
            //it's kind of label that doesn't affect anything
            //there is a set of constants: DefaultAuthenticationTypes.ApplicationCookie, ...
            //but it would require the Identity package to be installed


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            return Content($"Logged in as {name}");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}