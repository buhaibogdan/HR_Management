using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Premium.Users
{
    public class NormalUser : IUser
    {
        public string GetMinPoints()
        {
            return "A normal type of user, is a new user, with no points.";
        }
    }
}