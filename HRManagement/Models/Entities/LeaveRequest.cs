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
        public virtual int Id { get; set; }

        [ForeignKey("User")]
        public virtual int UserId { get; set; }

        [Required, ForeignKey("RequestType")]
        public virtual int RequestTypeId { get; set; }

        public virtual byte Status { get; set; }

        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^.{5,200}$", ErrorMessage="Comment must have between 5 and 200 characters.")]
        public virtual string Comment { get; set; }

        public virtual User User { get; set; }
        public virtual RequestType RequestType { get; set; }
        [NotMapped]
        public virtual IEnumerable<RequestedDay> RequestedDays { get; set; }
        [NotMapped]
        public virtual string StatusText { get; set; }
        public static bool isFreeDay(int day, int month)
        {
            HrDB db = new HrDB();
            var allFreeDays = db.FreeDays;
            foreach ( var item in allFreeDays )
            {
                if (item.day == day && item.month == month)
                {
                    return true;
                }
            }

            return false;
        }

        public LeaveRequest()
        {
            switch (Status)
            {
                case 0: StatusText = "Pending"; break;
                case 1: StatusText = "Accepted"; break;
                default: StatusText = "Denied"; break;
            }
        }
    }
}