using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, MaxLength(80)]
        public string Password { get; set; }
        [Required]
        public int GroupId { get; set; }

        public Employee Employee { get; set; }
    }
}