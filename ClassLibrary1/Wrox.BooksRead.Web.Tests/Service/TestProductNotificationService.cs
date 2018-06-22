using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Repository;
using Moq;

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

        [TestMethod]
        public void Product_Should_Have_Subscription()
        {
            Mock<IProductRepository> MockProductRepo = new Mock<IProductRepository>();
            Product product = new Product();
            Assert.IsTrue(product.ProductSubscriptions != null);
        }

        //if product change e.g.price or out of stock, user should have a notification to receive for update
        [TestMethod]
        public void Product_Should_Create_Notification_When_In_Change()
        {
            //Arrange
            Mock<IProductRepository> MockProductRepo = new Mock<IProductRepository>();
            Mock<INotificationRepository> MockNotificationRepo = new Mock<INotificationRepository>();
                 //Given there is a product with a new price changed.
            ProductViewModel PriceChangeProduct = new ProductViewModel( GenerateDummyProduct(100), null);
                 //Mock returns original record
            MockProductRepo.Setup(i => i.GetProductById((It.IsAny<int?>()))).Returns(GenerateDummyProduct(null));
                 //Set the dependency to the Product Ojbect
            Product product = new Product();
            product.ProductRepo = MockProductRepo.Object;
            product.NotificationRepo = MockNotificationRepo.Object;

            //Action
            product.Update(PriceChangeProduct);

            //Assert
            MockNotificationRepo.Verify(i => i.buildPriceChangeNotification(It.IsAny<Product>(), It.IsAny<ProductViewModel>()), Times.Once, "Noticication is not triggered when price is changed");
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
