using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceReference1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var one = await GetNumberText(1);

            ViewBag.RequestResult = one;
            return View();
        }

        private static async Task<string> GetNumberText(ulong num)
        {
            var httpBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            var address = new EndpointAddress(@"https://www.dataaccess.com/webservicesserver/NumberConversion.wso");

            var factory = new ChannelFactory<NumberConversionSoapType>(httpBinding, address);

            var request = new NumberToWordsRequest
            {
                Body = new NumberToWordsRequestBody
                {
                    ubiNum = num
                }
            };
            return (await factory.CreateChannel().NumberToWordsAsync(request)).Body.NumberToWordsResult;
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
