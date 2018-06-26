using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrox.BooksRead.Web.Controllers;
using Moq;
using System.Collections.Generic;
using Wrox.BooksRead.Web.Repository;
using Wrox.BooksRead.Web.Models;
using System.Web.Mvc;

namespace Wrox.BooksRead.Web.Tests.Controllers
{
    [TestClass]
    public class DummyControllerTest
    {
        [TestMethod]
        public void Constroller_Return_All_Product_To_View()
        {
           //Arrange 
            Mock<IProductRepository> MoqProductRepository = new Mock<IProductRepository>();
            MoqProductRepository.Setup(e => e.AllProduct()).Returns(
               new List<Product>()
                   {
                      new Product { Id=0, Name="Product HK" },
                      new Product { Id=1, Name="Product CN" }
                   }
                );
            DummyController Controller = new DummyController(MoqProductRepository.Object, null, null);

            //Act
            ViewResult VR = Controller.GetAllAction() as ViewResult;
            var Model = VR.Model as List<Product>;

            //Assert
            Assert.IsTrue(Model.Count == 2, "Expected Product Count is 2 ; Actual is" + Model.Count);
            Assert.IsTrue(Model[0].Name == "Product HK", "Expected 1st Product Name is Product HK ; Actual is " + Model[0].Name);
       }
    }

    

  
}
