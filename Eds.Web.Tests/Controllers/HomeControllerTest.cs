using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eds.Web;
using Eds.Web.Controllers;

namespace Eds.Web.Tests.Controllers
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
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test()
        {
            ClassA cl = new ClassB();
            string result=cl.Cod();
            ClassA cl2 = new ClassC();
            string result2 = cl2.Cod();
            Console.ReadLine();
        }
    }

    public class ClassA
    {
        public virtual string Cod()
        {
           return "A";
        }
    }
    public class ClassB: ClassA
    {
        public virtual new string  Cod()
        {
            return "B";
        }
    }
    public class ClassC : ClassA
    {
        public override  string Cod()
        {
            return "C";
        }
    }
}
