using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using HRManagement.Models;

namespace HRManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["DaysRequested"] = null;   
            return View();
             
        }

        public ActionResult Help()
        {   
            return View();
        }

        public ActionResult Leave()
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
