using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace HRManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {   
            return View();
        }

        public PartialViewResult Hello()
        {
            Thread.Sleep(1500);
            return PartialView("FreeDays");
        }
    }
}
