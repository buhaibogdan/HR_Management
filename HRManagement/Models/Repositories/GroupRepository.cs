using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models.Entities;

namespace HRManagement.Models.Repositories
{
    public class GroupRepository
    {
        private HrDB _db = new HrDB();

        public IQueryable<Group> GetAllGroups()
        {
            return _db.Groups;
        }
    }
}