using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;
using HRManagement.Models.Entities;

namespace HRManagement.Infrastructure
{
    public class CustomAuthAttr : AuthorizeAttribute
    {
        public const string manageUsers = "Manage_Users";
        public const string getUsers = "Get_Users";
        public const string requestDays = "Request_Free_Day";
        
        private HrDB _db = new HrDB();
        private bool hasRight;
        private List<string> rightsToCheck = new List<string>();

        private bool checkRights()
        {
            User authUser = (User)SessionPersister.get("userDetails");
            if (null == authUser)
            {
                return false;
            }
            List<GroupRight> rightsGroup = _db.GroupRights
                                  .Where(gr => gr.GroupId == authUser.GroupId).ToList<GroupRight>();
            foreach (var right in rightsGroup)
            {
                if (rightsToCheck.Contains(right.Right.Name))
                {
                    return true;
                }
            }

            return false;
        }

        public CustomAuthAttr(string right)
        {
            rightsToCheck.Add(right);
            hasRight = checkRights();
        }

        public CustomAuthAttr(List<string> rightsList)
        {
            this.rightsToCheck = rightsList;
            hasRight = checkRights();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!hasRight)
            {
                base.AuthorizeCore(httpContext);
                return false;
            }
            return base.AuthorizeCore(httpContext);
        }

    }
}