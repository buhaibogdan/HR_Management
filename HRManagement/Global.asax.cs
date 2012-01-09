using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity.Validation;
using System.Data.Entity;
using HRManagement.Models;
using HRManagement.Models.Entities;
using System.Data.SqlClient;

namespace HRManagement
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            Database.SetInitializer(new HrDBInitializer());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
    public class HrDBInitializer : DropCreateDatabaseAlways<HrDB>
    {
        protected override void Seed(HrDB context)
        {
            base.Seed(context);
            #region Request types
            context.RequestTypes.Add(new RequestType
            {
                Id = 1,
                Name = "Payed",
                Visible = 1
            });
            context.RequestTypes.Add(new RequestType
            {
                Id = 2,
                Name = "Medical",
                Visible = 1
            });
            context.RequestTypes.Add(new RequestType
            {
                Id = 3,
                Name = "Maternal",
                Visible = 1
            });
            #endregion
            #region FreeDays
            context.FreeDays.Add(new FreeDay
            {
                day = 1,
                month = 12
            });

            context.FreeDays.Add(new FreeDay
            {
                day = 25,
                month = 12
            });
            context.FreeDays.Add(new FreeDay
            {
                day = 26,
                month = 12
            });
            context.FreeDays.Add(new FreeDay
            {
                day = 5,
                month = 7
            });
            context.FreeDays.Add(new FreeDay
            {
                day = 1,
                month = 4
            });
            #endregion
            #region users
            context.Users.Add(new User
            {
                Id = 1,
                GroupId = 1,
                Email = "bb@email.com",
                Password = "123456",
                ConfirmPassword = "123456"
            });
            context.Users.Add(new User
            {
                Id = 2,
                GroupId = 3,
                Email = "manager@email.com",
                Password = "123456",
                ConfirmPassword = "123456"
            });
            context.Users.Add(new User
            {
                Id = 3,
                GroupId = 2,
                Email = "employee@email.com",
                Password = "123456",
                ConfirmPassword = "123456"
            });
            context.Users.Add(new User
            {
                Id = 4,
                GroupId = 2,
                Email = "employee2@email.com",
                Password = "123456",
                ConfirmPassword = "123456"
            });


            #endregion;
            #region Groups
            context.Groups.Add(new Group
            {
                Id = 1,
                Name = "Admin"
            });

            context.Groups.Add(new Group
            {
                Id = 2,
                Name = "Employee"
            });
            context.Groups.Add(new Group
            {
                Id = 3,
                Name = "Manager"
            });
            #endregion;

            #region Employees

            context.Employees.Add(new Employee
            {
                Id = 1,
                FirstName = "Bogdan",
                LastName = "Buhai",
                CNP = "1880201258741"
            });
            context.Employees.Add(new Employee
            {
                Id = 2,
                FirstName = "Luci",
                LastName = "Devil",
                CNP = "1666601222741"
            });
            context.Employees.Add(new Employee
            {
                Id = 3,
                FirstName = "Ana",
                LastName = "Baki",
                CNP = "2781201258741"
            });
            context.Employees.Add(new Employee
            {
                Id = 4,
                FirstName = "Gigi",
                LastName = "NumeDeFamilie",
                CNP = "1870201258742"
            });
            #endregion
            #region Rights
            context.Right.Add(new Right
            {
                Id = 1,
                Name = "Manage_Users",
            });
            context.Right.Add(new Right
            {
                Id = 2,
                Name = "Get_Users",
            });
            context.Right.Add(new Right
            {
                Id = 3,
                Name = "Request_Free_Day",
            });
            #endregion;

            #region Group Rights
            context.GroupRights.Add(new GroupRight
            {
                GroupId = 1,
                RightId = 1
            });
            context.GroupRights.Add(new GroupRight
            {
                GroupId = 1,
                RightId = 2
            });
            context.GroupRights.Add(new GroupRight
            {
                GroupId = 2,
                RightId = 3
            });
            context.GroupRights.Add(new GroupRight
            {
                GroupId = 3,
                RightId = 3
            });
            #endregion;
            //unique index for groups
            context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Group_Name ON Groups (Name)");
            context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_User_Email ON Users (Email)");
            context.SaveChanges();
        }
    }
}