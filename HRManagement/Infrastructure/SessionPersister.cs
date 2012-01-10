using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagement.Infrastructure
{
    public class SessionPersister
    {
        public static bool add(string index, object obj)
        {
            if (SessionPersister.isInSession(index))
            {
                return false;
            }
            HttpContext.Current.Session[index] = obj;
            return true;
        }

        public static object get(string index)
        {
            return HttpContext.Current.Session[index];
        }

        public static void remove(string index)
        {
            HttpContext.Current.Session.Remove(index);
        }

        private static bool isInSession(string index)
        {
            if (null == HttpContext.Current.Session[index])
            {
                return false;
            }
            return true;
        }
    }
}