using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wrox.BooksRead.Web.Models;

namespace Wrox.BooksRead.Web.Repository
{
    public class NotificationRepository
    {
    }
    public interface INotificationRepository
    {
        void buildPriceChangeNotification(Product originalProduct, ProductViewModel priceChangeProduct);
    }
}