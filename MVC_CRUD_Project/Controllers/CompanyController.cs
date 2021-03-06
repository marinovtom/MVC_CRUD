﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.BusinessLogic;
using MVC_CRUD_Project.Models;

namespace MVC_CRUD_Project.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            ViewBag.Title = "Company page";

            return View();
        }

        public ActionResult ListAll(string name = null)
        {
            ViewBag.Message = "List all Companies";

            ViewBag.DeleteError = TempData["ErrorMessage"];

            var data = CompanyProcessor.LoadCompanies();
            List<CompanyModel> companies = new List<CompanyModel>();

            foreach (var row in data)
            {
                companies.Add(new CompanyModel { Id = row.Id, Name = row.Name, CreationDate = row.CreationDate });
            }

            if(name != null)
            {
                companies = companies.Select(c => c).Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            return View(companies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyModel company)
        {
            if(ModelState.IsValid)
            {
                int createdCompany = CompanyProcessor.CreateCompany(company.Name, company.CreationDate);

                return RedirectToAction("ListAll");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            int deletedCompany = CompanyProcessor.DeleteCompany(id);
            if (deletedCompany == 0)
            {
                TempData["ErrorMessage"] = "Could not delete record!";
            }

            return RedirectToAction("ListAll");
        }

        public ActionResult Edit(int id)
        {
            var data = CompanyProcessor.GetCompanyForId(id);
            CompanyModel company = new CompanyModel { Id = data.Id, Name = data.Name, CreationDate = data.CreationDate };

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyModel company)
        {
            if (ModelState.IsValid)
            {
                int updatedCompany = CompanyProcessor.UpdateCompany(company.Id, company.Name, company.CreationDate);

                return RedirectToAction("ListAll");
            }

            return View();
        }
    }
}