using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models.Entities
{
    public class Employee
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }
        [MaxLength(80)]
        public string FirstName { get; set; }
        [MaxLength(80), Required]
        public string LastName { get; set; }
        [MaxLength(13)]
        public string CNP { get; set; }
        public int Manager { get; set; }

        public User User { get; set; }
    }
}