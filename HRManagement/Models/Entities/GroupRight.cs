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
        public virtual int GroupId { get; set; }

        [Key, ForeignKey("Right")]
        [Column(Order = 1)]
        public virtual int RightId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Right Right { get; set; }
    }
}