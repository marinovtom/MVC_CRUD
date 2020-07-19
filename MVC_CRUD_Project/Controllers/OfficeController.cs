using DataLibrary.BusinessLogic;
using MVC_CRUD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_Project.Controllers
{
    public class OfficeController : Controller
    {
        private void loadCompanyIds()
        {
            List<int> companyIds = new List<int>();
            var data = CompanyProcessor.LoadCompanies();
            foreach (var item in data)
            {
                companyIds.Add(item.Id);
            }

            ViewBag.CompanyList = new SelectList(companyIds);
        }

        private void loadCompanyNames()
        {
            List<string> companyNames = new List<string>();
            var data = CompanyProcessor.LoadCompanies();
            foreach (var item in data)
            {
                companyNames.Add(item.Name);
            }

            ViewBag.CompanyList = new SelectList(companyNames);
        }

        // GET: Office
        public ActionResult Index()
        {
            ViewBag.Title = "Office page";

            return View();
        }

        public ActionResult ListAll()
        {
            ViewBag.Message = "List all offices";

            var data = OfficeProcessor.LoadOffices();
            List<OfficeModel> offices = new List<OfficeModel>();
            foreach (var item in data)
            {
                var currentCompany = CompanyProcessor.GetCompanyForId(item.Company);

                offices.Add(new OfficeModel
                {
                    Id = item.Id,
                    Country = item.Country,
                    City = item.City,
                    Street = item.Street,
                    StreetNumber = item.StreetNumber,
                    IsHQ = item.isHQ,
                    Company = new CompanyModel { Id = currentCompany.Id, Name = currentCompany.Name, CreationDate = currentCompany.CreationDate }
                });
            }

            return View(offices);
        }

        public ActionResult Create()
        {
            loadCompanyNames();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfficeModel office)
        {
            office.Company.Id = CompanyProcessor.GetCompanyIdForName(office.Company.Name);
            //if (ModelState.IsValid)
            {
                int createdOffice = OfficeProcessor.CreateOffice(office.Country, office.City, office.Street, office.StreetNumber, office.IsHQ, office.Company.Id);

                return RedirectToAction("ListAll");
            }

            //return View();
        }

        public ActionResult Delete(int Id)
        {
            int deletedOffice = OfficeProcessor.DeleteOffice(Id);

            return RedirectToAction("ListAll");
        }

        public ActionResult Edit(int id)
        {
            loadCompanyNames();

            var data = OfficeProcessor.getOfficeForPrimaryKey(id);
            OfficeModel currentOffice = new OfficeModel
            {
                Country = data.Country,
                City = data.City,
                Street = data.Street,
                StreetNumber = data.StreetNumber,
                IsHQ = data.isHQ,
                Company = new CompanyModel { Id = data.Company }
            };

            return View(currentOffice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OfficeModel office)
        {
            office.Company.Id = CompanyProcessor.GetCompanyIdForName(office.Company.Name);

            //if (ModelState.IsValid)
            {
                int updatedOffice = OfficeProcessor.UpdateOffice(office.Id, office.Country, office.City, office.Street, office.StreetNumber, office.IsHQ, office.Company.Id);

                return RedirectToAction("ListAll");
            }

            //return View();
        }

        public ActionResult Employees(int id)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            var data = OfficeProcessor.getEmployeesForOfficeId(id);
            foreach (var item in data)
            {
                employees.Add(new EmployeeModel { Id = item.Id, FirstName = item.FirstName, LastName = item.LastName, StartingDate = item.StartingDate, 
                                Salary = item.Salary, VacationDays = item.VacationDays, ExperienceLevel = item.ExperienceLevel, OfficeId = id });
            }

            ViewBag.CurrentOfficeId = id;

            return View(employees);
        }

        public ActionResult AddEmployeeToOffice(int id)
        {
            var data = EmployeeProcessor.LoadAllEmployees();
            var employees = data.Select(e => new { text = e.FirstName + " " + e.LastName, value = e.Id }).ToList();

            EmployeeModel currentOfficeId = new EmployeeModel { OfficeId = id };

            ViewBag.EmployeeNamesList = new SelectList(employees, "value", "text");
            ViewBag.CurrentOfficeId = id;

            return View(currentOfficeId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployeeToOffice(EmployeeModel employee)
        {
            int addedEmployeeToOffice = OfficeEmployeeProcessor.AddEmployeeToOffice(employee.Id, employee.OfficeId);

            return RedirectToAction("Employees", new { id = employee.OfficeId });
        }

        public ActionResult RemoveEmployeeFromOffice(int id, int officeId)
        {
            int removedEmployee = OfficeEmployeeProcessor.RemoveEmployeeFromOffice(id, officeId);

            return RedirectToAction("Employees", new { id = officeId });
        }
    }
}