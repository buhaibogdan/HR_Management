using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Premium.Users
{
    public class VIPUser : IUser
    {
        public string GetMinPoints()
        {
            return "To become a VIP user you'll need to accumulate 120 points.";
        }
    }
}