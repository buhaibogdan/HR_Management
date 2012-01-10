using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models.Entities;
using HRManagement.Models;
using HRManagement.Infrastructure;

namespace HRManagement.Models.Repositories
{
    public class EmployeeRepository
    {
        private HrDB _db = new HrDB();

        public IQueryable<Employee> getAllEmployees()
        {
            return _db.Employees;
        }

        public List<Employee> GetPossibleManagersForUser(int id)
        {
            List<Employee> managers = _db.Employees.Where(e => e.Id != id).ToList<Employee>();
            
            managers.Add(new Employee{
                Id = 0,
                LastName = " [None] "
            });
            return managers;
        }

        public Employee getEmployeeById(int Id)
        {
            return _db.Employees.SingleOrDefault<Employee>(u => u.Id == Id);
        }

        public void addUser(Employee newEmployee)
        {
            _db.Employees.Add(newEmployee);
        }

        public void removeEmployee(Employee EmployeeToRemove)
        {
            _db.Employees.Remove(EmployeeToRemove);
        }
    }
}