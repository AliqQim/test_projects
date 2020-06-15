using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwagClient.Models;

namespace NSwagClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        async public Task<IActionResult> Index()
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                var serviceWrapper = new MyTestServiceName.Client(
                    "https://localhost:44354",
                    httpClient);

                double resAvg = await serviceWrapper.WeatherforecastPostAsync(1, 2);
                ViewBag.Output = $"среднее арифметическое от 1 и 2: {resAvg}; ";


                bool resChick = await serviceWrapper.WeatherforecastIsavailableforchattingupAsync(
                    new MyTestServiceName.Person
                    {
                        Age = 25,
                        IsFemale = true,
                        Name = "Света"
                    });

                ViewBag.Output += $"подкатывать ли к Свете: {resChick}; ";


            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
