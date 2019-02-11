using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "WTF?!:))";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Here is the contact information you will probably need:";

            return View();
        }
    }
}