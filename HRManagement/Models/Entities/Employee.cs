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
        public virtual int Id { get; set; }

        [MaxLength(80, ErrorMessage="First Name too long"), Display(Name="First name")]
        public virtual string FirstName { get; set; }

        [MaxLength(80, ErrorMessage = "First Name too long")]
        [Display(Name="Last name")]
        public virtual string LastName { get; set; }

        [RegularExpression(@"^.{13}$", ErrorMessage = "Incorrect CNP format.")]
        public virtual string CNP { get; set; }
        public virtual int Manager { get; set; }

        public User User { get; set; }
    }
}