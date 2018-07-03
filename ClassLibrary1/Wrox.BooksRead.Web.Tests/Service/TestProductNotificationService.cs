using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Repository;
using Moq;
using NUnit.Framework;
using FluentAssertions;

namespace Wrox.BooksRead.Web.Tests.Service
{
    /// <summary>
    /// Product should open subscription which allow users to subscribe to get the latest status of the product
    /// if product change e.g. price or out of stock, user should have a notification to receive for update
    /// `
    /// </summary>
    [TestClass]
    public class TestProductNotificationService
    {
        private Product productHandy;

       [TestInitialize]
        public void Setup()
        {
            productHandy = GenerateDummyProduct(100);
        }

        //if product change e.g.price or out of stock, user should have a notification to receive for update
        [TestMethod]
        public void Product_Should_Set_PriceChangedStatus_When_Price_Change()
        {
            ProductViewModel vmProduct = new ProductViewModel(GenerateDummyProduct(null), null);
            productHandy.Update(vmProduct);
            productHandy.PriceIsChanged.Should().Be(true);

        }

        private Product GenerateDummyProduct(int? price)
        {
            Product p = new Product();
            p.Id = 1;
            p.Name = "dummyproduct";
            p.Price = price != null? price : 90;
            return p;
        }
            
    }

    

    
}
