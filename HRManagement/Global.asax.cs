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
    public class HrDBInitializer : DropCreateDatabaseIfModelChanges<HrDB>
    {
        protected override void Seed(HrDB context)
        {
            base.Seed(context);

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

            context.SaveChanges();
        }
    }
}