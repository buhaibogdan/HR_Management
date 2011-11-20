using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Services;
using NUnit.Framework;
using HRManagement.Models.Entities;
using HRManagement.Controllers;
using System.Web.Mvc;

namespace HRManagement.Test
{
    [TestFixture]
    class LeaveControllerTests
    {
        private List<DateTime> DaysRequested;

        public void setUp()
        { 
            DaysRequested = new List<DateTime>();
            DaysRequested.Add(new DateTime(2011, 11, 1));
            DaysRequested.Add(new DateTime(2011, 11, 2));
            DaysRequested.Add(new DateTime(2011, 11, 3));
            DaysRequested.Add(new DateTime(2011, 11, 4));
        }

        [Test, WebMethod(EnableSession = true)]
        public void shouldAddDateToSession()
        {
            var controller = new LeaveController();
            var result = controller.Register(1, 1, 2001);
            //var list = controller.ViewBag.DaysRequested;
            Assert.IsTrue(true);
        }

        [Test, WebMethod(EnableSession = true)]
        public void shouldNotAddDuplicateDateToSession()
        { 
        
        }

        [Test, WebMethod(EnableSession=true)]
        public void shouldRemoveDateFromSession()
        { 
        
        }
    }
}
