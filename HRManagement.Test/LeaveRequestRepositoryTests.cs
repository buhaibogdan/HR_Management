using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagement.Models.Repositories;
using NUnit.Framework;

namespace HRManagement.Test
{
    [TestFixture]
    class LeaveRequestRepositoryTests
    {
        [Test]
        public void ClassShouldBeSingleton()
        {
            LeaveRequestRepository leaveRepo = LeaveRequestRepository.GetInstance();
            LeaveRequestRepository secondLeaveRepo = LeaveRequestRepository.GetInstance();

            Assert.AreSame(leaveRepo, secondLeaveRepo);
        }
    }
}
