using System.Data.Entity;

namespace Wrox.BooksRead.Web.Models
{
    public interface IEFDBEntities
    {
        DbSet<AspNetUser> AspNetUsers { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<ProductNotification> ProductNotifications { get; set; }
        DbSet<Product> Products { get; set; }
       // DbSet<ProductSubscription> ProductSubscriptions { get; set; }
        DbSet<UserProductNotification> UserProductNotifications { get; set; }
    }
}