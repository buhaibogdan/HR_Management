using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using HRManagement.Models;
using HRManagement.Models.Entities;
using System.Web.Services;

namespace HRManagement.Controllers
{
  
    public class LeaveController : Controller
    {
        HrDB _db = new HrDB();
        private List<DateTime> DaysRequested;
        
        public ActionResult Index()
        {
            var x = _db.RequestedDays;
            var model = _db.RequestTypes;
            return View(model);
        }

        [HttpPost]
        [WebMethod(EnableSession=true)]
        public ActionResult Register(int day, int month, int year)
        {
            DateTime requestDate = new DateTime(year, month+1, day);

            DaysRequested = new List<DateTime>();

            if (Session["DaysRequested"] != null)
            {
                DaysRequested = Session["DaysRequested"] as List<DateTime>;
                if ( ! DaysRequested.Contains(requestDate) )
                {
                    DaysRequested.Add(requestDate);
                }
            }
            else
            {
                DaysRequested.Add(requestDate);
                Session["DaysRequested"] = DaysRequested;
            }

            ViewBag.DaysRequested = Session["DaysRequested"];
            return PartialView("_RequestDates");
        }

        [HttpPost]
        [WebMethod(EnableSession = true)]
        public int RemoveDay(int day, int month, int year)
        {
            DateTime dayToDelete = new DateTime(year, month, day);
            if (Session["DaysRequested"] != null)
            {
                DaysRequested = Session["DaysRequested"] as List<DateTime>;
                if (DaysRequested.Contains(dayToDelete))
                {
                    DaysRequested.Remove(dayToDelete); 
                    return 1;
                }
                return 2;
            }
            return 0;
        }

        [HttpPost]
        [WebMethod(EnableSession = true)]
        public int saveRequest(int type, string user_comment)
        {
            if (Session["DaysRequested"] != null)
            {
                var LeaveRequest = _db.LeaveRequests;
                var RequestedDays = _db.RequestedDays;
                List<DateTime> DaysRequested = Session["DaysRequested"] as List<DateTime>;
                LeaveRequest newLeaveRequest = new LeaveRequest()
                {
                    RequestTypeId = type,
                    Comment = user_comment
                };
                LeaveRequest.Add(newLeaveRequest);
                _db.SaveChanges();
                foreach (var date in DaysRequested)
                {
                    RequestedDay reqDay = new RequestedDay(date);
                    reqDay.LeaveRequestId = newLeaveRequest.Id;
                    RequestedDays.Add(reqDay);
                }
                _db.SaveChanges();
                return 1;
            }
            return 0;
        }

    }
}
