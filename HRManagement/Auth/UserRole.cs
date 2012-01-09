using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using HRManagement.Models;
using HRManagement.Models.Entities;

namespace HRManagement.Auth
{
    public class UserRole : RoleProvider
    {
        private HrDB _db = new HrDB();
        #region NotImplemented
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        #endregion;
        public IEnumerable<Group> GetAvailableRoles()
        {
            return _db.Groups;
        }

        public override string[] GetRolesForUser(string email)
        {
            string[] group = new string[1];
            User user = _db.Users.SingleOrDefault(u => u.Email == email);
            if (null == user)
            {
                return group;
            }
            
            Group usersGroup = _db.Groups.SingleOrDefault(g=>g.Id == user.GroupId);
            if (null != group)
            {
                group[0] = usersGroup.Name;
            }

            return group;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string email, string groupId)
        {
            int id = int.Parse(groupId);

            if (null != _db.Users.SingleOrDefault(u => u.GroupId == id))
            {
                return true;
            }
            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}