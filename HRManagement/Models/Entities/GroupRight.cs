using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace HRManagement.Models.Entities
{
    public class GroupRight
    {
        [Key, ForeignKey("Group")]
        [Column(Order = 0)]
        public int GroupId { get; set; }

        [Key, ForeignKey("Right")]
        [Column(Order = 1)]
        public int RightId { get; set; }

        public Group Group { get; set; }
        public Right Right { get; set; }
    }
}