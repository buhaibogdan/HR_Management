using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Premium.Users
{
    public class NullUser : IUser
    {

        public string GetMinPoints()
        {
            return "This type of user is not available yet.";
        }
    }
}