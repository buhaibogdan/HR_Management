using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models.Entities
{
    public class Right
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
    }
}