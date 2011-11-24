using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HRManagement.Models.Entities;

namespace HRManagement.Models 
{
    public class HrDB : DbContext
    {
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups{ get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<GroupRight> GroupRights{ get; set; }
        public DbSet<FreeDay> FreeDays{ get; set; }
        public DbSet<RequestedDay> RequestedDays { get; set; } 
    }
}