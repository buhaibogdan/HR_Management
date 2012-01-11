using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models.Entities;


namespace HRManagement.Models.Repositories
{
    public class LeaveRequestRepository
    {
        private HrDB _db = new HrDB();
        private static LeaveRequestRepository _referenceToSelf;

        private LeaveRequestRepository() { }    
      
        public static LeaveRequestRepository GetInstance()
        {
            if (_referenceToSelf == null)
            { 
                _referenceToSelf = new LeaveRequestRepository();
            }
            return _referenceToSelf;
        }

        public IQueryable<LeaveRequest> GetAllRequests()
        {
            return _db.LeaveRequests;
        }

        public LeaveRequest GetRequestById(int id)
        {
            return _db.LeaveRequests.Find(id);
        }

    }
}