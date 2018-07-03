using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Web.Mvc;
using Wrox.BooksRead.Web.Controllers;
using Wrox.BooksRead.Web.Persistence;
using System.Collections.Generic;
using FluentAssertions;

namespace OSIM.IntegrationTest
{
    [TestClass]
    public class DummyControllerTest
    {
        private ApplicationContext context;
        [TestInitialize]
        public void SetUp()
        {
            context = new ApplicationContext();
        }

        [TestCleanup]
        public void TearDown()
        {
            context.Dispose();
        }

        [TestMethod]
        [TestCategory("Integration Test")]
        public void GetAllAction_WhenCall_ShouldReturnProductInFutureOnlyToView()
        {
            //Arranage
            Product[] products = new[]{ new Product { Id = 0, CreateDate = DateTime.Now.AddDays(1), Name = "Dummy1", Category = 0, Price = 0 } ,
                new Product { Id = 1, CreateDate = DateTime.Now.AddDays(2), Name = "Dummy2", Category = 0, Price = 0 },
                new Product { Id = 2, CreateDate = DateTime.Now.AddDays(-2), Name = "DummyObsolete", Category = 0, Price = 0 }
            };

            Category category = new Category { Id = 0, Name = "Dummy Category" };
            try
            {
                context.Categories.Add(category);
                context.Products.AddRange(products);

                context.SaveChanges();

                //When 
                DummyController controller = new DummyController(null, null, new UnitOfWork());
                var result = controller.GetAllAction();

                //Assert
                var resultProducts = result.ViewData.Model as List<Wrox.BooksRead.Web.Models.Product>;
                resultProducts.Should().HaveCount(2);
            }
            finally
            {
                //Tear Down
                context.Products.RemoveRange(products);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

    }
}
