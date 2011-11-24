using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models.Entities
{
    public class RequestedDay
    {//this class takes advantace of the implicit conventions of EF 4.1
        public int Id { get; set; }
        public int LeaveRequestId { get; set; }
        public DateTime Day { get; set; }

        public RequestedDay(DateTime newDay)
        {
            Day = newDay;
        }
    }
}