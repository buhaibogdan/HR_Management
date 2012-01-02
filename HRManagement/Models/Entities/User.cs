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
        public string Email { get; set; }
        [Required, MaxLength(80)]
        public string Password { get; set; }
        [Required]
        public int GroupId { get; set; }

        public Employee Employee { get; set; }

        public static bool validateCredentials(string email, string pass)
        {
            HrDB db = new HrDB();
            User authUser = db.Users.Single(u => (u.Email == email && u.Password == pass));
            if (null != authUser)
            {
                return true;
            }
            return false;
        }
    }
}