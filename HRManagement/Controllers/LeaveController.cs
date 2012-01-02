using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using HRManagement.Models;
using HRManagement.Models.Entities;
using System.Web.Services;
using System.Threading;

namespace HRManagement.Controllers
{

    public class LeaveController : Controller
    {
        HrDB _db = new HrDB();
        private List<DateTime> DaysRequested;
        
        public ActionResult Index()
        {
            var model = new LeaveForm();
            model.RequestType = _db.RequestTypes;
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
            }
            
            if (LeaveRequest.isFreeDay(day, month + 1))
            {
                DaysRequested.Remove(requestDate);
            }
            Session["DaysRequested"] = DaysRequested;
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
        public string saveRequest(int type, string user_comment)
        {
            if ( null == Session["DaysRequested"] )
            {
                return "You did not choose a day.";
            }
            var LeaveRequest = _db.LeaveRequests;
            var RequestedDays = _db.RequestedDays;
            List<DateTime> DaysRequested = Session["DaysRequested"] as List<DateTime>;

            if (DaysRequested.Count < 1) //kinda duplicate, to remove
            {
                return "You did not choose a day.";
            }
            LeaveRequest newLeaveRequest = new LeaveRequest()
            {
                RequestTypeId = type,
                Comment = user_comment.Trim(),
                UserId = 1
            };
            LeaveRequest.Add(newLeaveRequest);
            try
            {
                _db.SaveChanges();
                foreach (var date in DaysRequested)
                {
                    RequestedDay reqDay = new RequestedDay(date);
                    reqDay.LeaveRequestId = newLeaveRequest.Id;
                    RequestedDays.Add(reqDay);
                }
                _db.SaveChanges();
                Session["DaysRequested"] = null;
                return "Request successfully saved. Please wait for it to be validated by your manager.";
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                return "Your request is not valid.";
            }
            catch (Exception)
            {
                return "Your request could not be saved now. Please try again later.";
            }
        }

        public ActionResult MyRequests()
        {
            var model = _db.LeaveRequests
                           .Where(r => r.UserId == 1)
                           .OrderBy(r=>r.Id)
                           .ToList<LeaveRequest>();
            for (int i = 0; i < model.Count; i++)
            {
                int RequestId = model[i].Id;
                model[i].RequestedDays = _db.RequestedDays
                                            .Where(r => r.LeaveRequestId == RequestId);
            }

            return PartialView("_MyRequests", model);
        }

        public ActionResult Details(int id)
        {
            var model = GetRequest(id);
            return PartialView("_Details", model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = GetRequest(id);

            return PartialView("_Edit", model);
        }
        [HttpPost]
        public string Edit(int id, int type, string comment)
        {
            var request = _db.LeaveRequests.Single( r => r.Id == id );
            request.RequestTypeId = type;
            request.Comment = comment;
            try
            {
                _db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                return "Your request is not valid.";
            }
            catch (Exception)
            {
                return "Your request could not be saved now. Please try again later.";
            }
            return "Successfully saved.";
        }

        [HttpPost]
        public int Remove(int id)
        {
            var request = _db.LeaveRequests.Single( r=> r.Id == id);
            var days = _db.RequestedDays.Where(r => r.LeaveRequestId == id);
            foreach (var day in days)
            {
                _db.RequestedDays.Remove(day);
            }
            _db.LeaveRequests.Remove(request);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }

        private LeaveForm GetRequest(int id)
        {// ar merge in LeaveForm Class
            var model = new LeaveForm();
            model.LeaveRequest = _db.LeaveRequests.Single(r => r.Id == id);
            model.LeaveRequest.RequestedDays = _db.RequestedDays.Where(r => r.LeaveRequestId == id);
            model.RequestType = _db.RequestTypes.ToList<RequestType>();
            return model;
        }
    }
}
