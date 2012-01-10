using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Infrastructure;
using HRManagement.Models.Entities;
using HRManagement.Auth;
using HRManagement.ViewModels;
using HRManagement.Models.Repositories;

namespace HRManagement.Controllers
{
    //[CustomAuthAttr(CustomAuthAttr.manageUsers)]
    public class ManageUsersController : Controller
    {
        public ActionResult Index()
        {
            return View(new UserViewModel());
        }

        public ActionResult Details(int id)
        {
            UserRepository userRepo = new UserRepository();
            return PartialView("_UserDetails", userRepo.getUserById(id));
        }

        public ActionResult Edit(int id)
        {
            EditUserViewModel model = new EditUserViewModel(id);

            ViewData["groupsList"] = new SelectList(model.groups, "Id", "Name", model.user.GroupId);
            ViewData["groups"] = model.user.GroupId;

            ViewData["managersList"] = new SelectList(model.Managers, "Id", "LastName", model.user.Employee.Manager);
            ViewData["managers"] = model.user.Employee.Manager;

            return PartialView("_UserEdit", model);
        }

        [HttpPost]
        public string Edit(FormCollection editedUser)
        {
            if (!ModelState.IsValid)
            {
                return "You had some errors in the form.";

            }
            UserRepository userRepo = new UserRepository();
            User user = new User();
            Employee employee = new Employee();

            user.Id   = int.Parse(editedUser["user.id"]);
            user.Email= editedUser["user.Email"];
            employee.FirstName = editedUser["user.Employee.FirstName"];
            employee.LastName = editedUser["user.Employee.LastName"];
            employee.CNP = editedUser["user.Employee.CNP"];

            if (!string.IsNullOrEmpty(editedUser["Managers"]))
            {
                employee.Manager = int.Parse(editedUser["Managers"]);
            }

            user.GroupId = int.Parse(editedUser["groups"]);
            user.Employee = employee;

            userRepo.updateUser(user);

            if (!userRepo.Save())
            {
                return "User failed to updated. Try again later.";
            }

            return "User successfully updated.";
        }

        public ActionResult Create()
        {
            return PartialView("_UserCreate", new EditUserViewModel());
        }

        [HttpPost]
        public int Create(FormCollection form)
        {
            User newUser = new User();
            Employee newEmployee = new Employee();

            newUser.Email = form["user.Email"];
            newUser.GroupId = int.Parse(form["groups"]);
            newUser.Password = form["user.Password"];
            newUser.ConfirmPassword = form["user.ConfirmPassword"];
            
            newEmployee.FirstName = form["user.Employee.FirstName"];
            newEmployee.LastName = form["user.Employee.LastName"];
            newEmployee.Manager = int.Parse(form["Managers"]);
            newEmployee.CNP = form["user.Employee.CNP"];

            newUser.Employee = newEmployee;

            UserRepository userRepo = new UserRepository();
            userRepo.addUser(newUser);
            if (userRepo.Save())
            {
                return 1;
            }

            return 0;
        }

        [HttpPost]
        public int Delete(int id)
        {
            UserRepository userRepo = new UserRepository();
            userRepo.removeUserById(id);
            if (userRepo.Save())
            {
                return 1;
            }
            return 0;
        }
    }
}
