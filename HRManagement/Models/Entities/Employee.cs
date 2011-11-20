using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagement.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNP { get; set; }
        public int Id_Position { get; set; }
    }
}