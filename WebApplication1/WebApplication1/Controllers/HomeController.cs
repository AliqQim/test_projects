using aliksoft.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using aliksoft.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace Aliksoft.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public record IndexPageVM(string Content);
        public async Task<IActionResult> IndexAsync([FromServices] ApplicationDbContext dbContext)
        {
            string mainPageText = (await dbContext.Contents.SingleAsync(x => x.PageId == PageId.Main)).Content;
            return View(new IndexPageVM(mainPageText));
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("'Privacy' action executed");
            return View();
        }

        public IActionResult Throw()
        {
            throw new Exception("Test exception");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}