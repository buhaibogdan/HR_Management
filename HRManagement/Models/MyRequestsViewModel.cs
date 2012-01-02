using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models.Entities;

namespace HRManagement.Models
{
    public class MyRequestsViewModel
    {
        public LeaveRequest LeaveRequest { get; set; }
        public RequestedDay RequestedDay { get; set; }
    }
}
