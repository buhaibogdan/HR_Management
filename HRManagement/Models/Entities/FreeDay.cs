using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models
{
    public class FreeDay
    {
        public int Id { get; set; }
        [Required]
        public int day { get; set; }
        [Required]
        public int month { get; set; }
    }
}