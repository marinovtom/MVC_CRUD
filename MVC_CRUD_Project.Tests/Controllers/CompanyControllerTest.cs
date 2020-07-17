using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_CRUD_Project.Controllers;

namespace MVC_CRUD_Project.Tests.Controllers
{
    [TestClass]
    public class CompanyControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var companyController = new CompanyController();

            var result = companyController.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Company page", result.ViewBag.Title);
        }
    }
}
