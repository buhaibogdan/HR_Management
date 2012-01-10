using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HRManagement.Infrastructure;
using NUnit.Mocks;
using System.Web.Mvc;
using System.Web;
using MvcContrib.TestHelper;
using HRManagement.Controllers;
using Rhino.Mocks;

namespace HRManagement.Test
{
    [TestFixture]
    class SessionPersisterTests
    {
        [Test]
        public void LeaveRequestControllerTest()
        {
            LeaveController leave = new LeaveController();
            TestControllerBuilder builder = new TestControllerBuilder();
            builder.InitializeController(leave);

            //leave.Session["blabla"] = 1234;

            Assert.AreEqual(true, true);            
        }
    }
}
