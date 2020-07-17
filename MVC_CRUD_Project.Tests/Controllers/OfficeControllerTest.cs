using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_CRUD_Project.Controllers;

namespace MVC_CRUD_Project.Tests.Controllers
{
    [TestClass]
    public class OfficeControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            OfficeController controller = new OfficeController();

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Office page", result.ViewBag.Title);
        }
    }
}
