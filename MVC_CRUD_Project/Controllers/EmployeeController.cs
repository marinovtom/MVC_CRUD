using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using DataLibrary.BusinessLogic;
using MVC_CRUD_Project.Models;

namespace MVC_CRUD_Project.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListAll(string name = null)
        {
            ViewBag.DeleteError = TempData["ErrorMessage"];

            List<EmployeeModel> employees = new List<EmployeeModel>();
            var data = EmployeeProcessor.LoadAllEmployees();
            foreach (var item in data)
            {
                employees.Add(new EmployeeModel
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    StartingDate = item.StartingDate,
                    Salary = item.Salary,
                    VacationDays = item.VacationDays,
                    ExperienceLevel = item.ExperienceLevel
                });
            }

            if (name != null)
            {
                string nameLowerCase = name.ToLower();

                employees = employees.Select(e => e).Where(e => e.FirstName.ToLower().Contains(nameLowerCase) || 
                                                                e.LastName.ToLower().Contains(nameLowerCase)).ToList();
            }

            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                int createdEmployee = EmployeeProcessor.CreateEmployee(employee.FirstName, employee.LastName, employee.StartingDate, employee.Salary, employee.VacationDays, employee.ExperienceLevel);

                return RedirectToAction("ListAll");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = EmployeeProcessor.GetEmployeeById(id);
            EmployeeModel employee = new EmployeeModel
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                StartingDate = data.StartingDate,
                Salary = data.Salary,
                VacationDays = data.VacationDays,
                ExperienceLevel = data.ExperienceLevel
            };

            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                int updatedEmployee = EmployeeProcessor.UpdateEmployee(employee.Id, employee.FirstName, employee.LastName, employee.StartingDate, employee.Salary, employee.VacationDays, employee.ExperienceLevel);

                return RedirectToAction("ListAll");
            }

            return View();
        }

        public ActionResult Delete(int Id)
        {
            int deletedEmployee = EmployeeProcessor.DeleteEmployee(Id);
            if (deletedEmployee == 0)
            {
                TempData["ErrorMessage"] = "Could not delete record!";
            }

            return RedirectToAction("ListAll");
        }
    }
}