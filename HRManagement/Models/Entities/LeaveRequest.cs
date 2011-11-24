using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models.Entities
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RequestTypeId { get; set; }

        public byte Status { get; set; }

        [MinLength(5), MaxLength(200)]
        public string Comment { get; set; }
    }
}