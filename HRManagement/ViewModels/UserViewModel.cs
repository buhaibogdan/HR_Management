using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models.Entities;
using HRManagement.Models.Repositories;

namespace HRManagement.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public UserViewModel()
        { 
            UserRepository usersRepo = new UserRepository();
            EmployeeRepository employeeRepo = new EmployeeRepository();

            Users = usersRepo.getAllUsers();
            Employees = employeeRepo.getAllEmployees();
        }
    }
}
