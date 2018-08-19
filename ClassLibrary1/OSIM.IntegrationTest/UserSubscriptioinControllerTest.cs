using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrox.BooksRead.Web.Common;
using Wrox.BooksRead.Web.Controllers.Api;
using Wrox.BooksRead.Web.DTO;
using Wrox.BooksRead.Web.Persistence;

namespace OSIM.IntegrationTest
{
    [TestFixture]
    public class UserSubscriptioinControllerTest
    {
        private ApplicationContext context;
        [SetUp]
        public void SetUp()
        {
            context = new ApplicationContext();
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }

        [Test, Isolated]
        [Category("Integration Test")]
        public void GetUserNotification_WhenCall_ShouldReturnCorrectCountOfNotification()
        {
            //Arranage
            Product[] products = new[] { new Product { Id = 100, CreateDate = DateTime.Now.AddDays(1), Name = "Dummy1", Category = 0, Price = 0 } };
            //, new Product { Id = 101, CreateDate = DateTime.Now.AddDays(2), Name = "Dummy2", Category = 0, Price = 0 },
            //    new Product { Id = 102, CreateDate = DateTime.Now.AddDays(-2), Name = "DummyObsolete", Category = 0, Price = 0 } };

            var productNotification = new ProductNotification
            {
                Id = 1,
                Product = products[0],
                Notification = string.Format(Utility.PRODUCT_PRICE_CHANGE_NOTIFICATION,
                                new object[] {
                         products[0].Id,
                         products[0].Name,
                         products[0].Price.ToString(),
                         2

              }) };
            productNotification.UserProductNotifications.Add(new UserProductNotification { Id = 1, UserId = "1234", IsRead = 0, ProductNotificationId = 1 });

            var user = new AspNetUser()
            {
                Id = "1234",
                Name = "mockuser",
                UserName = "matt",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                AccessFailedCount = 0,
            };
            Category category = new Category { Id = 0, Name = "Dummy Category" };
           
                context.AspNetUsers.Add(user);
                context.Categories.Add(category);
                context.Products.AddRange(products);
                context.ProductNotifications.Add(productNotification);

                context.SaveChanges();

                //Act 
                UserNotificationController controller = new UserNotificationController(new UnitOfWork());
                var result = controller.GetUserNotification("1234");

                //Assert
                result.Should().HaveCount(1);
                         
       
        }
    }
}
