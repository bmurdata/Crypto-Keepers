using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cryptokeepers2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The DFS Data Junction - Powered by Crypto-Keepers";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Department of Financial Services";

            return View();
        }
    }
}