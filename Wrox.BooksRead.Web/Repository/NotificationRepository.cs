using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wrox.BooksRead.Web.Models;

namespace Wrox.BooksRead.Web.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        EFDBEntities _context = null;
        public NotificationRepository()
        {
            _context = new EFDBEntities();
        }
      
        public void buildPriceChangeNotification(Product originalProduct, ProductViewModel priceChangeProduct)
        {
            throw new NotImplementedException();
        }
    }
    public interface INotificationRepository
    {
        void buildPriceChangeNotification(Product originalProduct, ProductViewModel priceChangeProduct);
    }
}