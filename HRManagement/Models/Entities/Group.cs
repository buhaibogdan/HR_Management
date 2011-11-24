using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models
{
    public class Group
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
    }
}