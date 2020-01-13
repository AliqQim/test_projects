using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public class AjaxDto
        {
            public string Date { get; set; }
            public int Age { get; set; }
        }

        public JsonResult AjaxAction()
        {
            return Json(new AjaxDto
            {
                Date = DateTime.Now.ToLongDateString(),
                Age = 222
            });
        }
    }
}