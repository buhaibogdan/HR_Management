using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace HRManagement.Models.Entities
{
    public class GroupRight
    {
        [Key]
        [Column("id_group", Order=0)]
        public int Id_Group { get; set; }
        [Key]
        [Column("id_right", Order = 1)]
        public int Id_Right { get; set; }
    }
}