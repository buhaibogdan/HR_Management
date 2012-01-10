using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models.Entities;
using HRManagement.Models.Repositories;
using HRManagement.Models;

namespace HRManagement.ViewModels
{
    public class EditUserViewModel
    {
        public User user { get; set; }
        public IEnumerable<Group> groups { get; set; }
        public IEnumerable<Employee> Managers { get; set; }

        public EditUserViewModel(int id)
        {
            LoadUser(id);
            LoadGroups();
            LoadManagersFor(id);
        }

        public EditUserViewModel()
        {
            LoadGroups();
            LoadManagersFor(-1);
        }

        private void LoadUser(int id)
        {
            UserRepository userRepo = new UserRepository();
            user = userRepo.getUserById(id);
        }

        private void LoadGroups()
        {
            GroupRepository groupRepo = new GroupRepository();
            groups = groupRepo.GetAllGroups();
        }

        private void LoadManagersFor(int id)
        {
            EmployeeRepository employeeRepo = new EmployeeRepository();
            Managers = employeeRepo.GetPossibleManagersForUser(id);
        }
    }
}