using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagement.Models.Auth
{
    public class CustomPrincipal : System.Security.Principal.IPrincipal
    {
        public CustomPrincipal(CustomIdentity identity)
        {
            this.Identity = identity;
        }
        public System.Security.Principal.IIdentity Identity
        {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}