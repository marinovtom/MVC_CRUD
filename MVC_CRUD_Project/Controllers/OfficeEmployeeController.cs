using DataLibrary.BusinessLogic;
using MVC_CRUD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_Project.Controllers
{
    public class OfficeEmployeeController : Controller
    {
        // GET: OfficeEmployee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListAll()
        {
            List<OfficeEmployeeModel> officeEmployee = new List<OfficeEmployeeModel>();
            var data = OfficeEmployeeProcessor.LoadAll();
            foreach (var item in data)
            {
                var employee = EmployeeProcessor.GetEmployeeById(item.Employee);

                officeEmployee.Add(new OfficeEmployeeModel { Office = new OfficeModel { Id = item.Office }, Employee = new EmployeeModel { FirstName = employee.FirstName } });
            }

            return View(officeEmployee);
        }
    }
}