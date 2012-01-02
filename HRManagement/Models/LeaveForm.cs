using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models.Entities;

namespace HRManagement.Models
{
    public class LeaveForm
    {
        public LeaveRequest LeaveRequest { get; set; }
        public IEnumerable<RequestType> RequestType { get; set; }
    }
}