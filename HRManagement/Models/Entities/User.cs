using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagement.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int group_id { get; set; }
    }
}