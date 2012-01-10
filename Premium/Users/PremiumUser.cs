using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Premium.Users
{
    public class PremiumUser : IUser
    {
        public string GetMinPoints()
        {
            return "To become a Premium user you'll need to accumulate 50 points.";
        }
    }
}