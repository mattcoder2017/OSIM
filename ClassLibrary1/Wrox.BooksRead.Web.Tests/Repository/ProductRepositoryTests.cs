using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrox.BooksRead.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;
using Wrox.BooksRead.Web.Models;
using FluentAssertions;
using Wrox.BooksRead.Web.Tests.Repository;

namespace Wrox.BooksRead.Web.Tests.Repository
{
    [TestClass()]
    public class ProductRepositoryTests
    {
        [TestMethod]
        [TestCategory("Repository Test")]
        public void GetProductById_ProductDoesNotExist_ReturnNull()
        {
            var data = new Mock<DbSet<Product>>();
            var Products = new [] { new Product { Id = 1 }, new Product { Id = 2 }, new Product { Id = 3 } };
            data.SetDataSource(Products);
           
            var moqDB = new Mock<IEFDBEntities>();
            moqDB.SetupGet(i => i.Products).Returns(data.Object);
            var Repo = new ProductRepository(moqDB.Object);
            Repo.GetProductById(4).Should().BeNull();

        }


        
    }
}