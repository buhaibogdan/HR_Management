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
        public DbSet<Right> Right { get; set; }
        public DbSet<FreeDay> FreeDays{ get; set; }
        public DbSet<RequestedDay> RequestedDays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasRequired<Employee>(u=>u.Employee)
                .WithRequiredPrincipal(e => e.User)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}