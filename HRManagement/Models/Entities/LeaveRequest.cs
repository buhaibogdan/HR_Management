using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagement.Models.Entities
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int id_type { get; set; }
        public byte status { get; set; }
        public string comment { get; set; }
    }
}