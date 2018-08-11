using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wrox.BooksRead.Web.Models;

namespace Wrox.BooksRead.Web.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        IEFDBEntities _context = null;
        IEFDBEntities _readcontext = null;

        public NotificationRepository(IEFDBEntities context, IEFDBEntities readcontext)
        {
            _context = context;
            _readcontext = readcontext; 

        }
      
        public void buildPriceChangeNotification(Product originalProduct, ICollection<ProductSubscription> subscriptions, ProductNotification notification)
        {
            foreach(var subscription in subscriptions)
            { 
            _context.UserProductNotifications.Add(
                new UserProductNotification { ProductNotification = notification, UserId = subscription.UserId, IsRead = 0 }
                );
            }

        }
    }
    public interface INotificationRepository
    {
        void buildPriceChangeNotification(Product originalProduct, ICollection<ProductSubscription> subscriptions, ProductNotification notification);
    }
}