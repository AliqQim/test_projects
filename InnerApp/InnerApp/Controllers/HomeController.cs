using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnerApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var rnd = new Random();

            ViewBag.SessionId = Session.SessionID;

            int ctr = (int?)Session["ctr"] ?? 1;

            Session["ctr"] = ctr + 1;

            ViewBag.Counter = ctr;

            ViewBag.NextUrl = Url.Action(nameof(Index), new { dummie = rnd.Next() });

            ViewBag.CookiesStr = Request.Headers["Cookie"];



            int cookieValToSet = rnd.Next(100);
            Response.SetCookie(new HttpCookie(
                "cookieVal",
                cookieValToSet.ToString())
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax
            });

            ViewBag.CookieToSet = cookieValToSet;


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
    }
}