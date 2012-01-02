using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models.Entities
{
    public class RequestedDay
    {
        public virtual int Id { get; set; }
        [ForeignKey("LeaveRequest")]
        public virtual int LeaveRequestId { get; set; }
        public virtual DateTime Day { get; set; }
        public virtual LeaveRequest LeaveRequest { get; set; }

        public RequestedDay() { }
        public RequestedDay(DateTime newDay)
        {
            Day = newDay;
        }
    }
}