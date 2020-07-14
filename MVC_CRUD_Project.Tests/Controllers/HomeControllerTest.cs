using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_CRUD_Project;
using MVC_CRUD_Project.Controllers;

namespace MVC_CRUD_Project.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
