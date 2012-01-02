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
        [MaxLength(80)]
        public virtual string FirstName { get; set; }
        [MaxLength(80), Required]
        public virtual string LastName { get; set; }
        [MaxLength(13)]
        public virtual string CNP { get; set; }
        public virtual int Manager { get; set; }

        public User User { get; set; }
    }
}