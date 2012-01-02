using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models.Entities;
using System.Web.Mvc;
using System.Security.Principal;

namespace HRManagement.Models.Auth
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string name)
        {
            this.Name = name;
        }
        #region IIdentity members
        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return !string.IsNullOrEmpty(this.Name); }
        }
        
        public string Name{ get; private set; }
        #endregion
    }
}