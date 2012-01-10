using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models.Entities;
using HRManagement.Models;
using HRManagement.Infrastructure;

namespace HRManagement.Models.Repositories
{
    public class UserRepository
    {
        private HrDB _db = new HrDB();

        public IQueryable<User> getAllUsers()
        {
            return _db.Users;
        }

        public User getUserByEmail(string Email)
        {
            return _db.Users.SingleOrDefault<User>(u => u.Email == Email);
        }

        public User getUserById(int id)
        {
            return _db.Users.Find(id);
        }

        public void addUser(User newUSer)
        {
            _db.Users.Add(newUSer);
        }

        public void updateUser(User updatedUser)
        {
            User oldUser = _db.Users.Find(updatedUser.Id);
            Employee oldEmployee = _db.Employees.Find(updatedUser.Id);

            oldEmployee.FirstName = updatedUser.Employee.FirstName;
            oldEmployee.LastName = updatedUser.Employee.LastName;
            oldEmployee.CNP = updatedUser.Employee.CNP;
            oldEmployee.Manager = updatedUser.Employee.Manager;
            
            oldUser.Email = updatedUser.Email;
            oldUser.Employee = updatedUser.Employee;
            oldUser.GroupId = updatedUser.GroupId;
            oldUser.ConfirmPassword = oldUser.Password;
        }

        public void removeUser(User userToRemove)
        {
            _db.Users.Remove(userToRemove);
        }

        public void removeUserById(int id)
        {
            User user = _db.Users.SingleOrDefault(u => u.Id == id);
            _db.Users.Remove(user);
        }

        public bool Save()
        {
            try
            {
                var errors = _db.GetValidationErrors();
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}